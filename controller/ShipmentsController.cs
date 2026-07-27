using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.model;
using WebApplication5.Services;
using WebApplication5.DTOs;
namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly ILogger<ShipmentsController> _logger;

        public ShipmentsController(IShipmentService shipmentService, ILogger<ShipmentsController> logger)
        {
            _shipmentService = shipmentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllShipments()
        {
            var shipments = _shipmentService.GetAllShipments();
            return Ok(shipments);
        }

        [HttpGet("{id}")]
        public IActionResult GetShipmentById(int id)
        {
            var shipment = _shipmentService.GetShipmentById(id);

            if (shipment == null)
                return NotFound();

            return Ok(shipment);
        }

        [HttpPost]
        public IActionResult CreateShipment([FromBody] Shipment shipment)
        {
            if (shipment == null)
                return BadRequest();

            var createdShipment = _shipmentService.CreateShipment(shipment);
            _logger.LogInformation("Creating shipment {ShipmentNumber}", createdShipment.ShipmentNumber);
            var response = new ShipmentResponseDto { 
            ShipmentId=createdShipment.ShipmentId,
            ShipmentNumber=createdShipment.ShipmentNumber,
            Status=createdShipment.Status,
            DriverId=createdShipment.DriverId,
            CustomerId  =createdShipment.CustomerId,
            CreatedDate=createdShipment.CreatedDate,
            };
            return CreatedAtAction(
                nameof(GetShipmentById),
                new { id = createdShipment.ShipmentId },
                createdShipment);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateShipmentStatus(int id, [FromBody] UpdateShipmentRequestDto updateDto)
        {
            var updated = _shipmentService.UpdateShipmentStatus(id, updateDto.Status);

            if (!updated)
                return NotFound();

            _logger.LogInformation("Updated shipment {ShipmentId} status", id,updateDto.Status);
            return Ok("Shipment status updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipment(int id)
        {
            var deleted = _shipmentService.DeleteShipment(id);

            if (!deleted)
                return NotFound();

            _logger.LogInformation("Deleted shipment {ShipmentId}", id);
            return Ok("Shipment deleted successfully.");
        }
        [HttpGet("count")]
        public IActionResult getShipmentCount() {
            int totalShipment = _shipmentService.CountShipment();
            return Ok(totalShipment);
        }
        [HttpGet("latest")]
        public IActionResult GetLatestShipment() {
        var latestship= _shipmentService.GetLatestShipment();
            return Ok(latestship);
        }

    }
}
