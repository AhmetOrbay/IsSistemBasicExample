using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemVakaTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("MakeReservation")]
        public async Task<IActionResult> GetMakeReservation(ReservationMakeDto reservationMake)
        {
            var result = await _reservationService.MakeReservation(reservationMake);
            if(!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
