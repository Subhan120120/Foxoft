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
    public class AdminController : ControllerBase
    {
        private readonly IAttendanceConfigStore _configStore;
        private readonly IDeviceLockService _deviceLockService;
        private readonly IIpValidationService _ipService;
        private readonly string _connectionString;

        public AdminController(
            IAttendanceConfigStore configStore,
            IDeviceLockService deviceLockService,
            IIpValidationService ipService,
            IConfiguration configuration)
        {
            _configStore = configStore;
            _deviceLockService = deviceLockService;
            _ipService = ipService;
            _connectionString = configuration.GetConnectionString("SubConnString")
                ?? "Data Source=.\\SUBSQL;Initial Catalog=Tokla;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=sql123_;Encrypt=False;";
        }

        private subContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<subContext>();
            optionsBuilder.UseSqlServer(_connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), new[] { 233 });
            });
            return new subContext(optionsBuilder.Options);
        }

        [HttpGet("rules")]
        public async Task<IActionResult> GetRules()
        {
            await using var db = CreateDbContext();
            var stores = await db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Store && !x.IsDisabled)
                .ToListAsync();

            var rules = _configStore.GetAllStoreRules();

            // Əgər bazada olan bəzi filiallar hələ configdə yoxdursa, əlavə edirik
            foreach (var st in stores)
            {
                if (!rules.Any(r => string.Equals(r.StoreCode, st.CurrAccCode, StringComparison.OrdinalIgnoreCase)))
                {
                    var newRule = _configStore.GetStoreRule(st.CurrAccCode, st.CurrAccDesc ?? st.CurrAccCode);
                    rules.Add(newRule);
                }
            }

            return Ok(rules);
        }

        [HttpPost("rules")]
        public IActionResult SaveRule([FromBody] StoreAttendanceRule rule)
        {
            if (string.IsNullOrWhiteSpace(rule.StoreCode))
                return BadRequest(new { Message = "Filial kodu boş ola bilməz." });

            _configStore.SaveStoreRule(rule);
            return Ok(new { Success = true, Message = "Filial tənzimləmələri yadda saxlanıldı." });
        }

        [HttpGet("devices")]
        public IActionResult GetDevices()
        {
            var devices = _deviceLockService.GetAllLocks();
            return Ok(devices);
        }

        [HttpPost("devices/unlock")]
        public IActionResult UnlockDevice([FromBody] UnlockRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.CurrAccCode))
                return BadRequest(new { Message = "İşçi kodu boş ola bilməz." });

            bool ok = _deviceLockService.UnlockEmployeeDevice(req.CurrAccCode);
            if (ok)
                return Ok(new { Success = true, Message = "İşçinin cihaz kilidi uğurla sıfırlandı! Yeni telefonla daxil ola bilər." });

            return NotFound(new { Success = false, Message = "Bu işçiyə aid qeydiyyatda olan cihaz tapılmadı." });
        }

        [HttpGet("logs")]
        public async Task<IActionResult> GetRecentLogs([FromQuery] int limit = 50)
        {
            await using var db = CreateDbContext();

            var logs = await db.TrAttendanceLogs.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .OrderByDescending(x => x.LogDateTime)
                .Take(limit)
                .Select(x => new
                {
                    x.Id,
                    x.CurrAccCode,
                    EmployeeName = (!string.IsNullOrEmpty(x.DcCurrAcc.CurrAccDesc)
                        ? x.DcCurrAcc.CurrAccDesc
                        : ((x.DcCurrAcc.FirstName ?? "") + " " + (x.DcCurrAcc.LastName ?? "")).Trim()),
                    x.LogDateTime,
                    PunchType = x.PunchType.ToString(),
                    PunchTypeDesc = x.PunchType == PunchType.CheckIn ? "Giriş" :
                                    x.PunchType == PunchType.CheckOut ? "Çıxış" : x.PunchType.ToString(),
                    SourceMethod = x.SourceMethod.ToString(),
                    x.DeviceCode,
                    x.Location,
                    x.CreatedDate
                })
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("my-ip")]
        public IActionResult GetMyIp()
        {
            string ip = _ipService.GetClientIp(HttpContext);
            return Ok(new { ClientIp = ip });
        }

        public class UnlockRequest
        {
            public string CurrAccCode { get; set; } = string.Empty;
        }
    }
}
