﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongolatlon.Models.Entities
{
    public class LatLonEntity : MongoEntity
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}