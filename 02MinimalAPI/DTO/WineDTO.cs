namespace _02MinimalAPI.DTO
{
    public class WineDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public double alcohol { get; set; }
        public bool isChilean { get; set; }
        public bool isActive { get; set; }
        public DateTime createDate { get; set; }
    }
}
