using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.Observer
{
    public class BaggageInfo
    {
        private int flightNo;
        private string origin;
        private int location;
        public int FlightNumber
        {
            get { return this.flightNo; }
        }

        public string From
        {
            get { return this.origin; }
        }

        public int Carousel
        {
            get { return this.location; }
        }

        internal BaggageInfo(int flight, string from, int carousel) {
            this.flightNo = flight;
            this.origin = from;
            this.location = carousel;
        }
    }
}
