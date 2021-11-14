using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell()
        {
        }

        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
