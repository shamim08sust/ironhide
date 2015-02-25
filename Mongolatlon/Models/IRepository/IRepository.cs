using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongolatlon.Models.IRepository
{
    public interface IRepository<K>
    {
       ObjectId Insert(K item);
       IEnumerable<K> Find(QueryDocument document);
       IEnumerable<K> FindAll();
       ObjectId put(K item);
    }
}