using HotelAdministrationSystem.Contracts.Enums;

namespace HotelAdministrationSystem.Contracts.Actions
{
    public class RoomInfo
    {
        public int Capacity { get; set; }
        public RoomTypeOption RoomType { get; set; }
        public decimal Price { get; set; }
    }
}
