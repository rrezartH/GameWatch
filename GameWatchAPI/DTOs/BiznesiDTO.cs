namespace GameWatchAPI.DTOs
{
    public class BiznesiDTO
    {
        public byte[]? ProfilePicture { get; set; }
        public string Emri { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }
    }

    public class GetBiznesiDTO
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }
    }
}
