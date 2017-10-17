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
        public TacoParser()
        {   

            
        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            //DO not fail if one record parsing fails, return null
            Logger.Error("Parsing failed. Should have continued but returned null.");
            return null; //TODO Implement
        }
    }
}