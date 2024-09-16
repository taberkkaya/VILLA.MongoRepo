namespace Villa.Entity.Entities
{
    public class Product : BaseEntity
    {
        public string? ImgUrl { get; set; }
        public string? Category { get; set; }
        public string? Price { get; set; }
        public string? Title { get; set; }
        public int BedroomCount { get; set; }
        public int BathRoomCount { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int ParkingCount { get; set; }

    }
}
