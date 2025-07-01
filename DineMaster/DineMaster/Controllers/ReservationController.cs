using DineMaster.DTO;
using DineMaster.Repository;
using DineMaster.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationRepo _repo;
        public ReservationController(IReservationRepo repo)
        {
            this._repo = repo;
        }

        [HttpPost]
        [Route("AddReservation")]
        public async Task<IActionResult> AddReservation(CustomerReservationDTO customerReservationDTO)
        {
            //await _repo.AddReservation(customerReservationDTO);
            //return Ok(" Added Success");


            try
            {
                var result = await _repo.AddReservation(customerReservationDTO);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }

        }


        [HttpPost]
        [Route("AdminReservation")]
        public async Task<IActionResult> AdminReservation(CustomerReservationDTO adminReservation)
        {
            //await _repo.AdminReservation(adminReservation);
            //return Ok("Reservation Status Updated Successfully");

            try
            {
                var result = await _repo.AdminReservation(adminReservation);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetReservationDetails/{id}")]
        public async Task<IActionResult> GetReservationDetails(int id)
        {
            var det = await _repo.ReservationDetails(id);
            return Ok(det);
        }

        [HttpGet]
        [Route("GetAllReservations")]
        public async Task<IActionResult> GetAllReservations()
        {
            var res = await _repo.GetReservations();
            return Ok(res);
        }

        [HttpPut]
        [Route("CancelReservation")]
        public async Task<IActionResult> CancelReservation(ReservationCancelDTO dto)
        {
            await _repo.CancelReservation(dto);
            return Ok(new {message = "Cancelled Successfully" });
        }

        [HttpGet]
        [Route("GetUpcomingReservations/{id}")]
        public async Task<IActionResult> GetUpcomingReservations(int id)
        {
            
                var reservations = await _repo.GetUpcomingReservationsByUser(id);

                if (reservations == null || !reservations.Any())
                {
                    return NotFound(new {message = "No upcoming reservations found." });
                }

                return Ok(reservations);
            
            
        }


        [HttpPut("MarkCompleted/{id}")]
        public async Task<IActionResult> MarkCompleted(int id)
        {
            var result = await _repo.MarkReservationAsCompleted(id);
            if (!result)
                return NotFound("Reservation not found");

            return Ok("Reservation marked as completed");
        }

        [HttpGet]
        [Route("ReservationHistory/{id}")]
        public async Task<IActionResult> ReservationHistory(int id)
        {

            var reservations = await _repo.ReservationHistory(id);

            if (reservations == null || !reservations.Any())
            {
                return NotFound("No Reservation was found");
            }

            return Ok(reservations);


        }

        [HttpPut("AdminConfirm/{id}")]
        public async Task<IActionResult> AdminConfirm(int id)
        {
            var result = await _repo.AdminConfirm(id);
            if (!result)
                return NotFound("Reservation not found");

            return Ok(new {message = "Reservation marked as completed" });
        }

    }
}
