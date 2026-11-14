using System;
using System.Linq;
using System.Threading.Tasks;
using Foxoft.AttendanceWeb.Models;
using Foxoft.AttendanceWeb.Services;
using Foxoft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Foxoft.AttendanceWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IQrTokenService _qrService;
        private readonly IIpValidationService _ipService;
        private readonly IAttendanceConfigStore _configStore;

        public AttendanceController(
            IAttendanceService attendanceService,
            IQrTokenService qrService,
            IIpValidationService ipService,
            IAttendanceConfigStore configStore)
        {
            _attendanceService = attendanceService;
            _qrService = qrService;
            _ipService = ipService;
            _configStore = configStore;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var res = await _attendanceService.AuthenticateAsync(request);
            if (!res.Success)
                return BadRequest(res);

            return Ok(res);
        }

        [HttpPost("punch")]
        public async Task<IActionResult> Punch([FromBody] PunchRequest request)
        {
            var res = await _attendanceService.ProcessPunchAsync(request, HttpContext);
            if (!res.Success)
                return BadRequest(res);

            return Ok(res);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory([FromQuery] string currAccCode)
        {
            var logs = await _attendanceService.GetTodayLogsAsync(currAccCode);
            return Ok(logs);
        }

        [HttpGet("stores")]
        public async Task<IActionResult> GetStores()
        {
            var stores = await _attendanceService.GetStoresAsync();
            var list = stores.Select(x => new
            {
                StoreCode = x.CurrAccCode,
                StoreName = x.CurrAccDesc ?? x.CurrAccCode
            }).ToList();

            return Ok(list);
        }

        [HttpGet("kiosk-qr")]
        public IActionResult GetKioskQr([FromQuery] string storeCode)
        {
            if (string.IsNullOrWhiteSpace(storeCode))
                return BadRequest(new { Message = "Filial kodu göstərilməyib." });

            var rule = _configStore.GetStoreRule(storeCode);
            var qr = _qrService.GenerateKioskQr(storeCode);

            return Ok(new KioskQrResponse
            {
                StoreCode = storeCode,
                StoreName = rule.StoreName,
                QrToken = qr.token,
                QrBase64 = qr.qrBase64,
                ExpiresAtUtc = qr.expiresAtUtc,
                ValiditySeconds = qr.validitySeconds
            });
        }

        [HttpGet("client-info")]
        public IActionResult GetClientInfo()
        {
            string ip = _ipService.GetClientIp(HttpContext);
            return Ok(new
            {
                ClientIp = ip,
                ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
