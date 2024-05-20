using Performances.Models;
using System.Globalization;
using System.Text;

namespace Performances.DataAccessLayer
{
    public class PerformanceSqlRepository : IPerformanceRepos
    {
        //Perhaps implement some form of caching to avoid rereading the CSV file if it hasn’t changed, especially to avoid rereading every time a booking is linked to its destination.
        public string ConnectionString { get; private set; }

        public PerformanceSqlRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Performance GetDestinationById(int id)
        {
            try
            {
                return GetDestinations().First(d => d.Id == id);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidDataException($"No destination with id {id} was found.", e);
            }
        }

        public IEnumerable<Performance> GetPeformances()
        {
            var lines = .ReadAllLines(ConnectionString, Encoding.UTF8);

            IEnumerable<Performance> destinations = new List<Performance>();
            foreach (var line in lines.Skip(1))
            {
                if (line.Length > 0)
                {
                    var fields = line.Split(',');
                    destinations = destinations.Append(new Performance(Int32.Parse(fields[0]), fields[1], fields[2], Decimal.Parse(fields[3], CultureInfo.InvariantCulture), fields[4]));
                }
            }
            return destinations;
        }
    }
}
