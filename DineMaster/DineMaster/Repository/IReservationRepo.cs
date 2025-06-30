using DineMaster.DTO;
using DineMaster.Models;

namespace DineMaster.Repository
{
    public interface IReservationRepo
    {
        Task<CustomerReservationDTO> AddReservation(CustomerReservationDTO dto);
        Task<CustomerReservationDTO> AdminReservation(CustomerReservationDTO dto);

        //Task AdminReservation (AdminReservationDTO dto);
        Task<ReservationDetailsDTO> ReservationDetails (int id);
        Task<IEnumerable<ReservationDetailsDTO>> GetReservations();
        Task CancelReservation(ReservationCancelDTO dto);

        //Task<bool> DeleteReservationAsync(int reservationId);
        Task<List<Reservation>> GetUpcomingReservationsByUser(int id);
        Task<bool> MarkReservationAsCompleted(int id);

        Task<List<Reservation>>ReservationHistory(int id);
        Task<bool> AdminConfirm(int id);





    }
}
