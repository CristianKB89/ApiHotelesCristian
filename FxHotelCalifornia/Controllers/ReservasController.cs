using FxHotelCalifornia.Models;
using FxHotelCalifornia.Services;
using Microsoft.AspNetCore.Mvc;

namespace FxHotelCalifornia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly DbServices _dbServices;
        private readonly EmailSender _emailSender;

        public ReservasController(DbServices dbServices, EmailSender emailSender)
        {
            _dbServices = dbServices;
            _emailSender = emailSender;
        }

        [HttpGet]
        public ActionResult<List<Reserva>> GetReservas()
        {
            var reservas = _dbServices.GetReservas();

            if (reservas == null || reservas.Count == 0)
            {
                return NotFound("No se encontraron reservas.");
            }

            return Ok(reservas);
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> CreateReserva(Reserva reserva)
        {
            var reservaResult = _dbServices.CreateReserva(reserva);

            var email = reserva?.Usuario?.Email;
            var subject = $"Confirmación de su reserva con id {reservaResult.Id}";
            var message = "Su reserva ha sido confirmada. Gracias por elegir nuestro hotel.";
            await _emailSender.SendEmailAsync(email, subject, message);

            return Ok("Reserva realizada con éxito");
        }

        [HttpPut]
        public ActionResult UpdateReserva(Reserva reserva)
        {
            return Ok(_dbServices.UpdateReserva(reserva.Id, reserva));
        }
    }
}