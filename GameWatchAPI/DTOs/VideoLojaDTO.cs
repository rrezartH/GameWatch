namespace GameWatchAPI.DTOs
{
    public class VideoLojaDTO
    {
        public string Emri { get; set; } = null!;

    }
    public class GetVideoLojaDTO
    {
        public int Id { get; set; }
        public string Emri { get; set;}
    }
}
