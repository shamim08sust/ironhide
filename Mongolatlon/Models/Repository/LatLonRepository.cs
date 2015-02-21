using Mongolatlon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongolatlon.Models.Repository
{
    public class LatLonRepository : MongoRepository<LatLonEntity>
    {
        public LatLonRepository()
            : base("tb_latlon")
        {

        }
    }
}