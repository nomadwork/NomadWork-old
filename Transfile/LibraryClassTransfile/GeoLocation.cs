using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassTransfile
{
    
    public class GeoLocation
    {
   
        public int LocationId { get; set; }

        public double Latitude { get; set; }
   
        public double Longitude { get; set; }

        public string LocationName { get; set; }
    }
}
