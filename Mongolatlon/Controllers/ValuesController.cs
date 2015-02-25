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
            //IList<LocEntity> en = new List<LocEntity>();

            //en.Add(new LocEntity()
            //  {
            //      Lon = lon,
            //      Lat = lat
            //  });
            //LatLonEntity entity = new LatLonEntity();
            //entity.loc = en;

            LatLonEntity entity = new LatLonEntity();
            entity.Lon = lon;
            entity.Lat = lat;

            return latlondb.Insert(entity);
        }

        [Route("api/main/find")]
        [HttpGet]
        public object find(double lon, double lat)
        {


            var loc = latlondb.FindAll();

            LatLonEntity lt = new LatLonEntity();

            double cDst = 7 * 1000000;
            double lwLat = 0.00, lwLon = 0.00;

            foreach (var l in loc)
            {
                //lt.Lon = l.Lon;
                //lt.Lat = l.Lat;

                var lat2 = l.Lat;
                var lon2 = l.Lon;

                var R = 6371; // km Radius of earth
                var dLat = ConvertToRadians((lat2 - lat));
                var dLon = ConvertToRadians((lon2 - lon));

                // Haversine (great circle) calculation for Lat/Long points

                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                        Math.Cos(ConvertToRadians(lat)) * Math.Cos(ConvertToRadians(lat2)) *
                        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

                var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                var d = R * c;

                if (d < cDst)
                {
                    cDst = d;

                    lwLat = lat2;
                    lwLon = lon2;


                }

            }
            QueryDocument entity = new QueryDocument { { "Lon", lwLon }, { "Lat", lwLat } };


            //BsonDocument pipeline = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(loc);

            return latlondb.Find(entity);



        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
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
