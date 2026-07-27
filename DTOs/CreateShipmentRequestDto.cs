using System.ComponentModel.DataAnnotations;
namespace WebApplication5.DTOs
{
    public class CreateShipmentRequestDto
    {
        [Required(ErrorMessage ="shipment number is required")]
        public string ShipmentNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        [Required(ErrorMessage = "customer id is required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "driver id is required")]

        public int DriverId { get; set; }
    }
}
