using System.Globalization;

namespace Performances.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public int ArtistId { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Performance(int performanceid, int artistid, string location, string date, string time)
        {
            PerformanceId = performanceid;
            ArtistId = artistid;
            Location = location;
            Date = date;
            Time = time;
        }

        public override string ToString()
        {
            return $"PerformanceId: {PerformanceId}, ArtistId: {ArtistId}, Location: {Location}, date: {Date}, Time: {Time}";
        }

        
    }
}
