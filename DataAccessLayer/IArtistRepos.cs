using Performances.Models;

namespace Performances.DataAccessLayer
{
    public interface IArtistRepos
    {
        public Performance GetBookingById(int id);
        public IEnumerable<Performance> GetBookings();
        public Performance AddBooking(Performance performance);
        public void DeleteBooking(Performance performance);
    }
}
