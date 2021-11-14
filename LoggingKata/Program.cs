using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            logger.LogInfo("Log initialized, locating two Taco Bells furthest from one another.");

            string[] lines = File.ReadAllLines(csvPath);
            if(lines.Length == 0)
            {
                logger.LogError("files has no input");
            }

            if(lines.Length == 1)
            {
                logger.LogWarning("file has only one line");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(line => parser.Parse(line)).ToArray();

            //location algorithm
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                //loop through first location
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    //loop through other locations to compare distance from first location
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                     {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                     }


                }


            }

            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest apart.");
   
        }
    }
}
