namespace Foxoft.Models.ViewModel
{
    public class ClaimViewModel
    {
        public string ClaimCode { get; set; } = string.Empty;
        public string ClaimDesc { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryDesc { get; set; } = string.Empty;
        public byte ClaimTypeId { get; set; }
        public string ClaimTypeDesc { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}
