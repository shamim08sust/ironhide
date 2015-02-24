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

        [Route("api/main/insert")]
        [HttpGet]
        public object insert(double lon, double lat)
        {
            LatLonEntity entity = new LatLonEntity();
            entity.Lat = lat;
            entity.Lon = lon;

            return latlondb.Insert(entity);

        }
        [Route("api/main/find")]
        [HttpGet]
        public object find(double lon, double lat)
        {
            QueryDocument entity = new QueryDocument {  { "Lon", lon },{ "Lat", lat } };
           
            return latlondb.Find(entity);
        }

        [Route("api/main/findall")]
        [HttpGet]
        public object findall()
        {
            var loc = latlondb.FindAll();
            //LatLonEntity myDeserializedObj = (LatLonEntity)JavaScriptConvert.DeserializeObject(latlondb.FindAll(), typeof(LatLonEntity));
           // List<LatLonEntity> myDeserializedObjList = (List<LatLonEntity>).Json.JsonConvert.DeserializeObject(latlondb.FindAll(), typeof(List<LatLonEntity>));
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
