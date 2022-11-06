using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
