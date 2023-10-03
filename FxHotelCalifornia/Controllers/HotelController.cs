using FxHotelCalifornia.Models;
using FxHotelCalifornia.Services;
using Microsoft.AspNetCore.Mvc;

namespace FxHotelCalifornia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly DbServices _dbServices;

        public HotelController(DbServices dbServices)
        {
            _dbServices = dbServices;
        }

        [HttpGet]
        public ActionResult<List<Hotel>> GetHoteles()
        {
            var hoteles = _dbServices.GetHotels();

            if (hoteles == null || hoteles.Count == 0)
            {
                return NotFound("No se encontraron hoteles.");
            }

            return Ok(hoteles);
        }

        [HttpGet("hoteles-con-habitaciones-habilitadas")]
        public ActionResult<List<Hotel>> GetHotelesConHabDisponibles()
        {
            var hoteles = _dbServices.GetHotelesConDisponibilidad();

            if (hoteles == null || hoteles.Count == 0)
            {
                return NotFound("No se encontraron hoteles con habitaciones disponibles.");
            }

            return Ok(hoteles);
        }

        [HttpPost]
        public ActionResult<Hotel> CreateHotel(Hotel hotel)
        {
            _dbServices.CreateHotel(hotel);
            return Ok(hotel);
        }

        [HttpPut]
        public ActionResult UpdateHotel(Hotel hotel)
        {
            return Ok(_dbServices.UpdateHotel(hotel.Id, hotel));
        }
    }
}