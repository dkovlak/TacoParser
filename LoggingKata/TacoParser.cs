namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            
            var cells = line.Split(',');

            
            if (cells.Length < 3)
            {
                
                logger.LogError("Less than three argumants.");
                
                return null; 
            }

            double latitude = double.Parse(cells[0]);
            double longitiude = double.Parse(cells[1]);
            string name = cells[2];

            var point = new Point() { Latitude = latitude, Longitude = longitiude };
            var tacoBell = new TacoBell { Name = name, Location = point};
            return tacoBell;
        }
    }
}