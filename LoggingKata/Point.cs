namespace LoggingKata
{
    public struct Point
    {
        double Longitude { get; set; }
        double Latitude { get; set; }

        public Point(double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        
    }
}