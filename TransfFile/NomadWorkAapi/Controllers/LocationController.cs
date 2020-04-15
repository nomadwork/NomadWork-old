using System.Collections.Generic;
using LibraryTrasfFile.locationClass;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace NomadWorkAapi.Controllers
{
    [Route("[controller]")]
    public class LocationController : Controller
    {
        // GET location/name
        [HttpGet("{name}")]
        public ActionResult<List<GeoLocation>> Get(string name)
        {
            return new GeolocationController().ListLocation(name);
        }

        // GET location
        [HttpGet]
        public ActionResult<List<GeoLocation>> Get()
        {
            return new GeolocationController().ListLocation();
        }

        //GET location/""/id
        [HttpGet("{name}/{id}")]
        public GeoLocation Get(string name, int id)
        {
            return new GeolocationController().GetGeoLocation(id);
        }

        // POST location
        [HttpPost]
        public bool Post([FromBody] GeoLocation location)
        {
            return new GeolocationController().InsertLocation(location);
        }

        // PUT location
        [HttpPut]
        public bool Put([FromBody] GeoLocation location)
        {
            return new GeolocationController().InsertLocation(location);
        }
    }
}
