using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Logger.Info("Log initialized");
            var path = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";
            Logger.Debug("Created csv Path variable");

            var lines = File.ReadAllLines(path);
            if (lines.Length == 0)
            {
                Logger.Error("cvs file is missing or empty.");
            }
            else if (lines.Length == 1)
            {
                Logger.Warn("Can't compare, there is only one element");
            }
            
            var parser = new TacoParser();
            Logger.Debug("Initialized our Parser");
            var locations = lines.Select(line => parser.ParseTacos(line))
                .OrderBy( loc => loc.Location.Longitude)
                .ThenBy( loc => loc.Location.Latitude)
                .ToArray();
            
            ITrackable locationA = null;
            ITrackable locationB = null;

            double distance = 0;
            Logger.Info("Comparing distance between locations");
            foreach (var locA in locations)
            {
                //Logger.Debug("Checking origin location.");
                var origin = new Coordinate
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude
                };
                
                foreach (var locB in locations)
                {
                    //Logger.Debug("Checking destination location.");
                    var destination = new Coordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };
                    //Logger.Info("Setting distance between the two points.");
                    var nDistance = GeoCalculator.GetDistance(origin, destination);
                    if (nDistance > distance)
                    {
                        //Logger.Info("If the new distance was greater than the previous, setting new values.");
                        locationA = locA;
                        locationB = locB;
                        distance = nDistance;
                    }
                }
            }
            if (locationA == null || locationB == null)
            {
                Logger.Error("Failed to find furthest locations.");
                Console.WriteLine("Failed to find furthest locations.");
                Console.ReadLine();
                return;
            }
            Logger.Info("Should Consol.WriteLine with furthest values.");
            Console.WriteLine($"The two Tacobells with the greatest distance are: {locationA.Name} and {locationB.Name}");
            Console.WriteLine($"These two locations are {distance} miles apart.");
            Console.ReadLine();
        }
    }
}