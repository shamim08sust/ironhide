using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongolatlon.Models.IEntities
{
    public interface ILatLonEntity
    {
         double Lon { get; set; }
         double Lat { get; set; }

    }
}