using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode
{
    public static class NetworkConnectivityHelper
    {
        private static bool _lastKnownStatus = true;
        private static DateTime _lastCheckedTime = DateTime.MinValue;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromSeconds(5);
        private static readonly SemaphoreSlim _lock = new(1, 1);

        private static readonly SocketsHttpHandler _httpHandler = new()
        {
            ConnectTimeout = TimeSpan.FromSeconds(2),
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };

        private static readonly HttpClient _httpClient = new(_httpHandler)
        {
            Timeout = TimeSpan.FromSeconds(3)
        };

        public static event Action? InternetRestored;

        /// <summary>
        /// Checks if an active network interface is present and can reach the internet.
        /// </summary>
        public static Task<bool> IsInternetAvailableAsync(CancellationToken ct = default)
            => IsInternetAvailableAsync(forceRefresh: false, ct);

        /// <summary>
        /// Checks if an active network interface is present and can reach the internet, with optional cache bypass.
        /// </summary>
        public static async Task<bool> IsInternetAvailableAsync(bool forceRefresh, CancellationToken ct = default)
        {
            if (!forceRefresh && DateTime.UtcNow - _lastCheckedTime < CacheDuration)
                return _lastKnownStatus;

            await _lock.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if (!forceRefresh && DateTime.UtcNow - _lastCheckedTime < CacheDuration)
                    return _lastKnownStatus;

                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    _lastKnownStatus = false;
                    _lastCheckedTime = DateTime.UtcNow;
                    return false;
                }

                bool wasOffline = !_lastKnownStatus;
                bool probeSuccess = await ProbeConnectivityAsync(ct).ConfigureAwait(false);

                _lastKnownStatus = probeSuccess;
                _lastCheckedTime = DateTime.UtcNow;

                if (wasOffline && probeSuccess)
                {
                    try
                    {
                        InternetRestored?.Invoke();
                    }
                    catch
                    {
                        // Ignore subscriber errors
                    }
                }

                return probeSuccess;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch
            {
                _lastKnownStatus = false;
                _lastCheckedTime = DateTime.UtcNow;
                return false;
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Synchronous wrapper for internet availability check.
        /// Executes on a thread pool thread to prevent deadlocks on WinForms UI thread.
        /// </summary>
        public static bool IsInternetAvailable(int timeoutMs = 3000, bool forceRefresh = false)
        {
            try
            {
                using var cts = new CancellationTokenSource(timeoutMs);
                return Task.Run(() => IsInternetAvailableAsync(forceRefresh, cts.Token)).GetAwaiter().GetResult();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Professional replacement for legacy CheckForInternetConnection method.
        /// </summary>
        public static bool CheckForInternetConnection(int timeoutMs = 3000)
            => IsInternetAvailable(timeoutMs);

        /// <summary>
        /// Checks whether a specific provider service (e.g. WhatsApp Evolution API or SMS gateway) is reachable.
        /// </summary>
        public static async Task<bool> IsProviderReachableAsync(string? serverUrl, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(serverUrl))
                return false;

            if (!Uri.TryCreate(serverUrl.Trim(), UriKind.Absolute, out Uri? uri))
                return false;

            try
            {
                using var client = new TcpClient();
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                cts.CancelAfter(TimeSpan.FromSeconds(3));

                int port = uri.Port > 0 ? uri.Port : (uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? 443 : 80);
                await client.ConnectAsync(uri.Host, port, cts.Token).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> ProbeConnectivityAsync(CancellationToken ct)
        {
            // 1. Fast parallel TCP handshake to primary anycast DNS/HTTPS servers (port 443)
            // Port 443 is used because port 53 is often blocked on corporate/guest Wi-Fi networks.
            try
            {
                using var fastCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                fastCts.CancelAfter(TimeSpan.FromMilliseconds(1500));

                var probe1 = ProbeTcpPortAsync("1.1.1.1", 443, fastCts.Token);
                var probe2 = ProbeTcpPortAsync("8.8.8.8", 443, fastCts.Token);

                var completed = await Task.WhenAny(probe1, probe2).ConfigureAwait(false);
                if (await completed.ConfigureAwait(false))
                {
                    fastCts.Cancel();
                    return true;
                }

                var remaining = (completed == probe1) ? probe2 : probe1;
                if (await remaining.ConfigureAwait(false))
                    return true;
            }
            catch (OperationCanceledException) when (!ct.IsCancellationRequested)
            {
                // Fast probe timed out, fall through to HTTP fallback
            }
            catch
            {
                // Fall through to HTTP fallback
            }

            // 2. HTTP probe fallback to standard NCSI / generate_204 endpoints
            // Handles enterprise proxies and captive portal environments.
            try
            {
                using var httpCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                httpCts.CancelAfter(TimeSpan.FromSeconds(2));

                var http1 = ProbeHttpEndpointAsync("http://www.gstatic.com/generate_204", httpCts.Token);
                var http2 = ProbeHttpEndpointAsync("http://www.msftconnecttest.com/connecttest.txt", httpCts.Token);

                var completedHttp = await Task.WhenAny(http1, http2).ConfigureAwait(false);
                if (await completedHttp.ConfigureAwait(false))
                {
                    httpCts.Cancel();
                    return true;
                }

                var remainingHttp = (completedHttp == http1) ? http2 : http1;
                return await remainingHttp.ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> ProbeTcpPortAsync(string host, int port, CancellationToken ct)
        {
            try
            {
                using var client = new TcpClient();
                await client.ConnectAsync(host, port, ct).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> ProbeHttpEndpointAsync(string url, CancellationToken ct)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
