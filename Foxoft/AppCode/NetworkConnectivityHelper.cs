using System;
using System.Net.Http;
using System.Net.NetworkInformation;
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

                bool probeSuccess = await ProbeConnectivityAsync(ct);
                _lastKnownStatus = probeSuccess;
                _lastCheckedTime = DateTime.UtcNow;
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

        private static async Task<bool> ProbeConnectivityAsync(CancellationToken ct)
        {
            try
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                cts.CancelAfter(TimeSpan.FromSeconds(3));

                // Quick DNS probe
                var hostEntry = await System.Net.Dns.GetHostEntryAsync("1.1.1.1");
                if (hostEntry != null)
                    return true;
            }
            catch
            {
                // Fallback to quick HTTP probe
            }

            try
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                cts.CancelAfter(TimeSpan.FromSeconds(3));

                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(3);

                using var response = await client.GetAsync("http://www.google.com/generate_204", HttpCompletionOption.ResponseHeadersRead, cts.Token);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
