using Mongolatlon.Models.Entities;
using Mongolatlon.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Mongolatlon.Controllers
{

    public class ValuesController : ApiController
    {
        private static LatLonRepository latlondb = new LatLonRepository();

        [Route("api/main/shamim")]
        [HttpGet]
        public object insert(double lat, double lon)
        {
            LatLonEntity entity = new LatLonEntity();
            entity.Lat = lat;
            entity.Lon = lon;

            return latlondb.Insert(entity);

        }
        [Route("api/main/find")]
        [HttpGet]
        public object find(double lat, double lon)
        {
            QueryDocument entity = new QueryDocument { { "Lat", lat }, { "Lon", lon } };

            return latlondb.Find(entity);
        }

        [Route("api/main/findall")]
        [HttpGet]
        public object findall()
        {
            return latlondb.FindAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
