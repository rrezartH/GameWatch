namespace GameWatchAPI.DTOs
{
    public class KonzolaDTO
    {
        public string Modeli { get; set; } = null!;
    }
    public class GetKonzolaDTO
    {
        public int Id { get; set; }
        public string Modeli { get; set; } = null!;
    }
}
