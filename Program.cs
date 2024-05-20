using Performances.DataAccessLayer;
using Performances.Models;
using Performances.Service;

namespace Performances
{

internal class Program
{

    public class MenuOption
    {
        public string? Label { get; set; }
        public Action<PerformanceService>? Method { get; set; }
    }

    static void Main(string[] args)
{
    
while (true)
{
                var PerformanceConnectionString = "Server=localhost;Port=3306;Database=examadvsoftware;Uid=root;Pwd=Femboygaming*0121346";
                var PerformanceService = SetUpPerformanceService(PerformanceConnectionString); // Implementation does not work

            {
                var menuOptions = new Dictionary<int, MenuOption>() {
                    { 1, new MenuOption() {Label = "1. Show all artists with a popularity higher than a value you specify, in alphabetical order", Method = GetPerformance} }, // not implemented
                    { 2, new MenuOption() {Label = "2. Update the artist's popularity", Method = GetPerformance}}, // not mplemented
                    { 3, new MenuOption() {Label = "3. Average popularity responses", Method = GetAllPerformance}}, // not corectly implemented
                    { 4, new MenuOption() {Label = "4. Add a new performance", Method = AddPerformance}},
                    { 5, new MenuOption() {Label = "5. Delete a performance", Method = DeletePerformance}},
                    { 6, new MenuOption() {Label = "6. Export all performances to a CSV file", Method = ExportPerformance}}, // not implemented
                    { 7, new MenuOption() {Label = "7. Exit", Method = null }}
                };

                Console.WriteLine("Choose a menu option:");
                foreach (var option in menuOptions)
                {
                    Console.WriteLine($"{option.Key}. {option.Value.Label}");
                }

                int optionId = 0;
                while (optionId == 0)
                {
                    while (!Int32.TryParse(Console.ReadLine(), out optionId))
                        Console.WriteLine("  You did not provide a valid number. Please try again:");

                    if (!menuOptions.ContainsKey(optionId))
                    {
                        Console.WriteLine("  You did not provide a option. Please try again:");
                        optionId = 0;
                    }
                }

                var chosenOption = menuOptions[optionId];
                if (chosenOption.Method == null)
                    break;
                chosenOption.Method(PerformanceService);
            }
        }
    }

        private static PerformanceService SetUpPerformanceService(string performanceConnectionString)
        {
            return new PerformanceService(new performance)
        }

        // METHODS

        private static void GetAllPerformance(PerformanceService performanceService)
        {
            Console.WriteLine("Showing all known performances:");
            foreach (var performance in performanceService.GetAllPerformances())
                Console.WriteLine(performance);
        }
        private static void AddPerformance(PerformanceService performanceService)
        {
            Console.WriteLine("Collecting information needed to create a new performance:");
            
            Console.WriteLine("  Please give the performance id:");
            int performanceId = 0;
            Performance? performance = null;
            while (performance == null)
            {
                while (!Int32.TryParse(Console.ReadLine(), out performanceId))
                    Console.WriteLine("    You did not provide a valid number. Please try again:");

                try
                {
                    performance = performanceService.GetPerformance(performanceId);
                }
                catch (InvalidDataException)
                {
                    Console.WriteLine("    The Performanceid you provded doesn't exist. Please try again:");
                }
            }
            Console.WriteLine("Please give the ArtistId:");
            int numberOfGuests;
            while (!Int32.TryParse(Console.ReadLine(), out numberOfGuests))
                Console.WriteLine("    You did not provide a valid number. Please try again:");

            Console.WriteLine("Please give the date");
            int numberOfNights;
            while (!Int32.TryParse(Console.ReadLine(),out numberOfNights))
                Console.WriteLine("    You did not provide a valid number. Please try again:");


            /*Console.WriteLine("Proposed performance:");
            var performanceadd = new Booking(-1, destination, numberOfGuests, numberOfNights);
            Console.WriteLine(performance);*/

            Console.WriteLine("Would you like to create this performance? (Y/N)");
            var options = new Dictionary<char, bool> { { 'N', false }, { 'n', false }, { 'Y', true }, { 'y', true } };
            char chosenOption;
            while (!options.Select(o => o.Key).Contains(chosenOption = Console.ReadKey().KeyChar))
                Console.WriteLine("  You did not provide a valid option. Please try again:");
            if(options[chosenOption])
                Console.WriteLine($"\r\nPerformance created:\r\n{Performance.AddPerformance(Performance)}".ReplaceLineEndings("\r\n  "));
            }
        

        private static void DeletePerformance(PerformanceService performanceService)
        {
            Console.WriteLine("Collecting information needed to delete a Performance:");

            Console.WriteLine("Please give the id of the performance you would like to delete:");
            int performanceId = 0;
            performance? performance = null;
            while (performance == null)
            {
                while (!Int32.TryParse(Console.ReadLine(), out performanceId))
                    Console.WriteLine("    You did not provide a valid number. Please try again:");

                try
                {
                    performance = performanceService.GetPerformance(performanceId);
                }
                catch (InvalidDataException)
                {
                    Console.WriteLine("    The performance id you provded doesn't exist. Please try again:");
                }
            }

            Console.WriteLine("Proposed performance:");
            Console.WriteLine(performance);

            Console.WriteLine("Would you like to delete this performance? (Y/N)");
            
            var options = new Dictionary<char, bool> { { 'N', false }, { 'n', false }, { 'Y', true }, { 'y', true } };
            char chosenOption;
            while (!options.Select(o => o.Key).Contains(chosenOption = Console.ReadKey().KeyChar))
                Console.WriteLine("  You did not provide a valid option. Please try again:");
            if (options[chosenOption])
            {
                performanceService.DeletePerformance(performance);
                Console.WriteLine($"\r\nPerformance deleted.");
            }
        }
            // Updating popularity (not implemented yet)
            private static void Updatepopularity(PerformanceService performanceService)
            {

            }

            // Exporting to csv (not implemented yet)
            private static void Exportcsv(PerformanceService performanceService, string filename)
            {

            }

            

            }
        }
    

