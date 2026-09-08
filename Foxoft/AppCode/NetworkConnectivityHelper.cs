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

        public static event Action? InternetRestored;

        /// <summary>
        /// Checks if an active network interface is present and can reach the internet.
        /// </summary>
        public static async Task<bool> IsInternetAvailableAsync(CancellationToken ct = default)
        {
            if (DateTime.UtcNow - _lastCheckedTime < CacheDuration)
                return _lastKnownStatus;

            await _lock.WaitAsync(ct);
            try
            {
                if (DateTime.UtcNow - _lastCheckedTime < CacheDuration)
                    return _lastKnownStatus;

                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    _lastKnownStatus = false;
                    _lastCheckedTime = DateTime.UtcNow;
                    return false;
                }

                bool wasOffline = !_lastKnownStatus;
                bool probeSuccess = await ProbeConnectivityAsync(ct);

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
        /// </summary>
        public static bool IsInternetAvailable()
        {
            try
            {
                return IsInternetAvailableAsync().GetAwaiter().GetResult();
            }
            catch
            {
                return false;
            }
        }

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
                await client.ConnectAsync(uri.Host, port, cts.Token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> ProbeConnectivityAsync(CancellationToken ct)
        {
            // 1. Fast TCP probe to public DNS (1.1.1.1:53 or 8.8.8.8:53) - reliable and fast (<200ms)
            if (await ProbeTcpPortAsync("1.1.1.1", 53, TimeSpan.FromSeconds(2), ct))
                return true;

            if (await ProbeTcpPortAsync("8.8.8.8", 53, TimeSpan.FromSeconds(2), ct))
                return true;

            // 2. HTTP probe to standard generate_204 endpoints
            if (await ProbeHttpEndpointAsync("http://www.gstatic.com/generate_204", TimeSpan.FromSeconds(3), ct))
                return true;

            if (await ProbeHttpEndpointAsync("http://www.msftconnecttest.com/connecttest.txt", TimeSpan.FromSeconds(3), ct))
                return true;

            return false;
        }

        private static async Task<bool> ProbeTcpPortAsync(string host, int port, TimeSpan timeout, CancellationToken ct)
        {
            try
            {
                using var client = new TcpClient();
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                cts.CancelAfter(timeout);

                await client.ConnectAsync(host, port, cts.Token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> ProbeHttpEndpointAsync(string url, TimeSpan timeout, CancellationToken ct)
        {
            try
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                cts.CancelAfter(timeout);

                using var handler = new SocketsHttpHandler
                {
                    ConnectTimeout = timeout
                };
                using var client = new HttpClient(handler);
                client.Timeout = timeout;

                using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cts.Token);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
