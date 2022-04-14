using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Location
    {
        public string lat { get; set; }
        public string @long { get; set; }
        public string locality { get; set; }
        public string country { get; set; }
    }

    public class Circuit
    {
        public string circuitId { get; set; }
        public string url { get; set; }
        public string circuitName { get; set; }
        public Location Location { get; set; }
    }

    public class CircuitTable
    {
        public List<Circuit> Circuits { get; set; }
    }

    public class MRDataTracks
    {
        public string xmlns { get; set; }
        public string series { get; set; }
        public string url { get; set; }
        public string limit { get; set; }
        public string offset { get; set; }
        public string total { get; set; }
        public CircuitTable CircuitTable { get; set; }
    }

    public class Root
    {
        public MRDataTracks MRData { get; set; }
    }
}
