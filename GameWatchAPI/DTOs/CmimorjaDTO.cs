namespace GameWatchAPI.DTOs
{
    public class CmimorjaDTO
    {
        public int NrLojtareve { get; set; }
        public decimal Cmimi { get; set; }
        public int BiznesiId { get; set; }
    }
    public class GetCmimiDTO
    {
        public int Id { get; set; }
        public int NrLojtareve { get; set; }
        public decimal Cmimi { get; set; }
        public int BiznesiId { get; set; }
    }
}
