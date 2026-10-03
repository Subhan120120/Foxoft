namespace Foxoft.Models.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string? UserDesc { get; set; }
        public string Companies { get; set; } = string.Empty;
        public int CompanyCount { get; set; }
        public bool IsDisabled { get; set; }
    }
}
