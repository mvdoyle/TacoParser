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
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            var locations = lines.Select(line => parser.Parse(line)).ToArray();

            ITrackable tacoBell1 = new TacoBell();
            ITrackable tacoBell2 = new TacoBell();

            double distance = 0;

            //for (int i = 0; i < locations.Length; i++)
            foreach(var i in locations)
            {
                //var locA = locations[i];
                var locA = i;
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                //for (int j = 0; j < locations.Length; j++)
                foreach(var j in locations)
                {
                    //var locB = locations[j];
                    var locB = j;
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if(corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
 
                }

            }

            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name}");

            
        }
    }
}
