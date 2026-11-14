using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Foxoft.AttendanceWeb.Services
{
    public interface IIpValidationService
    {
        string GetClientIp(HttpContext context);
        bool IsIpAllowed(string clientIp, IEnumerable<string> allowedIps);
    }

    public class IpValidationService : IIpValidationService
    {
        public string GetClientIp(HttpContext context)
        {
            if (context == null) return string.Empty;

            // X-Forwarded-For yoxlanışı
            if (context.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor) && !string.IsNullOrWhiteSpace(forwardedFor))
            {
                string firstIp = forwardedFor.ToString().Split(',')[0].Trim();
                if (IPAddress.TryParse(firstIp, out _))
                    return firstIp;
            }

            // X-Real-IP yoxlanışı
            if (context.Request.Headers.TryGetValue("X-Real-IP", out var realIp) && !string.IsNullOrWhiteSpace(realIp))
            {
                string trimmed = realIp.ToString().Trim();
                if (IPAddress.TryParse(trimmed, out _))
                    return trimmed;
            }

            // Connection RemoteIpAddress
            var remoteIp = context.Connection.RemoteIpAddress;
            if (remoteIp != null)
            {
                // IPv4 mapped to IPv6 handling
                if (remoteIp.IsIPv4MappedToIPv6)
                    remoteIp = remoteIp.MapToIPv4();

                return remoteIp.ToString();
            }

            return "127.0.0.1";
        }

        public bool IsIpAllowed(string clientIp, IEnumerable<string> allowedIps)
        {
            if (string.IsNullOrWhiteSpace(clientIp)) return false;

            var list = allowedIps?.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
            if (list == null || list.Count == 0) return true; // Əgər IP tənzimlənməyibsə keçir

            if (list.Contains("*") || list.Contains("0.0.0.0/0")) return true;

            // Normalizasiya
            if (IPAddress.TryParse(clientIp, out var parsedClientIp))
            {
                if (parsedClientIp.IsIPv4MappedToIPv6)
                    parsedClientIp = parsedClientIp.MapToIPv4();
                clientIp = parsedClientIp.ToString();
            }

            foreach (var rule in list)
            {
                // Exact match
                if (string.Equals(clientIp, rule, StringComparison.OrdinalIgnoreCase))
                    return true;

                // Localhost uyğunluğu
                if ((clientIp == "127.0.0.1" || clientIp == "::1") && (rule == "localhost" || rule == "127.0.0.1"))
                    return true;

                // Wildcard match (məs. 192.168.1.*)
                if (rule.EndsWith(".*"))
                {
                    string prefix = rule[..^2];
                    if (clientIp.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                        return true;
                }

                // CIDR match (məs. 192.168.1.0/24)
                if (rule.Contains('/') && IsInSubnet(parsedClientIp, rule))
                    return true;
            }

            return false;
        }

        private static bool IsInSubnet(IPAddress? address, string subnet)
        {
            if (address == null) return false;

            string[] parts = subnet.Split('/');
            if (parts.Length != 2) return false;

            if (!IPAddress.TryParse(parts[0], out var subnetAddress) || !int.TryParse(parts[1], out int prefixLength))
                return false;

            byte[] addressBytes = address.GetAddressBytes();
            byte[] subnetBytes = subnetAddress.GetAddressBytes();

            if (addressBytes.Length != subnetBytes.Length)
                return false;

            int fullBytes = prefixLength / 8;
            int remainingBits = prefixLength % 8;

            for (int i = 0; i < fullBytes; i++)
            {
                if (addressBytes[i] != subnetBytes[i])
                    return false;
            }

            if (remainingBits > 0 && fullBytes < addressBytes.Length)
            {
                int mask = (byte)(0xFF << (8 - remainingBits));
                if ((addressBytes[fullBytes] & mask) != (subnetBytes[fullBytes] & mask))
                    return false;
            }

            return true;
        }
    }
}
