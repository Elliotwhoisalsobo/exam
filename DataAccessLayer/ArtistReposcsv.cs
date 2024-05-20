using Performances.Models;
using System.Globalization;

namespace Performances.DataAccessLayer
{
    public class ArtistReposcsv : IArtistRepos
    {
        //Perhaps implement some form of caching to avoid rereading the CSV file if it hasn’t changed, especially to avoid rereading every time a booking is linked to its destination.
        public string Filename { get; private set; }

        public ArtistReposcsv(string filename)
        {
            Filename = filename;
        }

        public Performance GetPerformancebyid(int id)
        {
            try
            {
                return GetPerformancebyid().First(d => d.Id == id);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidDataException($"No destination with id {id} was found.", e);
            }
        }

        public IEnumerable<Destination> GetDestinations()
        {
            var lines = File.ReadAllLines(Filename, Encoding.UTF8);

            IEnumerable<Destination> destinations = new List<Destination>();
            foreach (var line in lines.Skip(1))
            {
                if (line.Length > 0)
                {
                    var fields = line.Split(',');
                    destinations = destinations.Append(new Destination(Int32.Parse(fields[0]), fields[1], fields[2], Decimal.Parse(fields[3], CultureInfo.InvariantCulture), fields[4]));
                }
            }
            return destinations;
        }
    }
}
