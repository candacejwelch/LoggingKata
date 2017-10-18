namespace LoggingKata
{
    public struct Point
    {
        decimal Longitude { get; set; }
        decimal Latitude { get; set; }

        public Point(decimal latitude, decimal longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        
    }
}