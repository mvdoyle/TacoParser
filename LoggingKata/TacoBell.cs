using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell()
        {
        }

        public TacoBell(string name, Point location)
        {
            Name = name;
            Location = location;
        }

        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
