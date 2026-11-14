using Foxoft.AppCode.Service;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Foxoft.AttendanceWeb.Services
{
    public interface IAttendanceConfigStore : Foxoft.AppCode.Service.IAttendanceConfigStore { }

    public class AttendanceConfigStore : Foxoft.AppCode.Service.AttendanceConfigStore, IAttendanceConfigStore
    {
        public AttendanceConfigStore(IWebHostEnvironment env)
            : base(Path.Combine(env.ContentRootPath, "App_Data", "attendance_config.json"))
        {
        }
    }
}
