using Performances.DataAccessLayer;
using Performances.Models;

namespace Performances.Service
{
    public class PerformanceService
    {
        public IPerformanceRepos PerformanceRepos { get; private set; }
        public IArtistRepos ArtistRepos { get; private set; }

        public PerformanceService(IPerformanceRepos performanceRepos, IArtistRepos artistRepos)
        {
            PerformanceRepos = performanceRepos;
            ArtistRepos = artistRepos;
        }
        
        // Get basic info 
        public IEnumerable<Performance> GetAllPerformance()
        {
            return PerformanceRepos.GetPerformances();
        }

        // Get basic info by id
        public Performance GetPerformance(int id)
        {
            return PerformanceRepos.GetPerformanceById(id);
        }

        //  4. AddPerformance
        public Performance AddPerformance(Performance performance) 
        {
            return PerformanceRepos.AddPerformance(performance);
        }

        // 5. Delete Performance
        public void DeletePerformance(Performance performance)
        {
            PerformanceRepos.DeletePerformance(performance);
        }

        // Basis of 1 (get by popularity)
        public IEnumerable<Performance> GetAllPerformances()
        {
            try
            {
                return PerformanceRepos.GetPerformances();
            }
            catch (IOException)
            {
                return new List<Performance>();
            }
        }
        /*
        public Booking GetBooking(int id)
        {
            return BookingRepository.GetBookingById(id);
        }
        */
        //public Booking CalculateBookingPrice(Booking booking)
        //{
        //    booking.TotalPrice = booking.Destination.AverageHotelPricePerNight * booking.NumberOfGuests * booking.NumberOfNights;
        //    return booking;
        //}
    }
}
