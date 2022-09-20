namespace _02MinimalAPI.DTO
{
    public class WineCreateDTO
    {
        public string name { get; set; }
        public double alcohol { get; set; }
        public bool isChilean { get; set; }
        public bool isActive { get; set; }
    }
}
