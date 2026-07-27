using System.ComponentModel.DataAnnotations;

namespace WebApplication5.DTOs
{
    public class UpdateShipmentRequestDto
    {
        [Required(ErrorMessage ="status is required to update ")]
        public string Status { get; set; }=string.Empty;
    }
}
