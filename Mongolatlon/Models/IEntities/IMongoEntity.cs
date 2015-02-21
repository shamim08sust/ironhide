using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongolatlon.Models.IEntities
{
    public interface IMongoEntity
    {
        ObjectId Id { set; get; }

    }
}