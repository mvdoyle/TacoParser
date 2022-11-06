namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogWarning("less than three items.   incomplete data");
                return null; 
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;    
            var tacoBell = new TacoBell();
            tacoBell.Name = cells[2];
            tacoBell.Location = point;
            
            return tacoBell;
        }
    }
}