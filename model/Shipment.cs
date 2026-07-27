namespace WebApplication5.model
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string ShipmentNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
    }
}
