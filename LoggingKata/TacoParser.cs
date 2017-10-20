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

        public ITrackable Parse(string line)
        {
            //DO not fail if one record parsing fails, return null
            try
            {
                var record = new Record();
                var values = line.Split(',');
                var point = new Point(Decimal.Parse(values[0]), Decimal.Parse(values[1]));
                record.Location = point;

                record.Name = values[2].Split('.')[0].Replace("/", "").Replace("\"", "");
                return record;
            }
            catch (Exception e)
            {
                Logger.Error("Parsing failed. Should have continued but returned null.");
                return null; //TODO Implement
            }
            
        }
    }
}