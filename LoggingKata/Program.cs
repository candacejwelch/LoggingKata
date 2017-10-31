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
            var locations = lines.Select(line => parser.ParseTacos(line));
            Console.WriteLine(locations);
            //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            //HINT:  You'll need two nested forloops

            //GeoCalculator
        }
    }
}