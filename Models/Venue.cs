using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappierU.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueStreet { get; set; }
        public string VenueNeighbor { get; set; }
        public string VenueCity { get; set; }
        public string VenueZipCode { get; set; }
        public int VenueAvailableSeats { get; set; }

    }
}
