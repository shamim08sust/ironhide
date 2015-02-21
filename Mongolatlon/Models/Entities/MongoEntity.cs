using MongoDB.Bson;
using Mongolatlon.Models.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Mongolatlon.Models.Entities
{
    public class MongoEntity : IMongoEntity
    {
        public ObjectId Id { get; set; }
    }
}