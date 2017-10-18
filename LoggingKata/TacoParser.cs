using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using System.IO;


namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {

        //Constructor, use this to send information to the instance
        public TacoParser()
        {   

            
        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            //DO not fail if one record parsing fails, return null
            
            var record = new Record();
            var values = line.Split(',');
            var point = new Point(Decimal.Parse(values[0]), Decimal.Parse(values[1]));
            record.Location = point;

            record.Name = values[2].Split('.')[0].Replace("/","").Replace("\"","");
            
            Logger.Error("Parsing failed. Should have continued but returned null.");
            return null; //TODO Implement
        }
    }
}