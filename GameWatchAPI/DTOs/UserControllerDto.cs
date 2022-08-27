namespace GameWatchAPI.DTOs
{
    public class UserControllerDto
    {
        public string Emri { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public int? LokaliId { get; set; }
        public int? BiznesiId { get; set; }
    }
}
