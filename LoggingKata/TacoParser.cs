using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable ParseTacos(string line)
        {
            var values = line.Split(',');

            if (values.Length < 3)
            {
                Logger.Error("Must have at least three elements to parse into ITrackable");
                return null;
            }
            
            try
            {
                Logger.Info("Initalized object, Should parse Name and Location inside new instances of object.");
                var record =  new Record
                {
                    Name = values[2].Split('.')[0].Replace("/", "").Replace("\"", ""),
                    Location = new Point(double.Parse(values[1]), double.Parse(values[0]))
                };

                Logger.Info("Should return Record Object with Location points and Location name.");
                return record;
            }
            catch (Exception e)
            {
                Logger.Error("Passed Checkpoint of Length < 3 but Parsing failed. Should have continued but returned null.", e);
                Console.WriteLine(e);
                return null;
            }
            
        }
    }
}