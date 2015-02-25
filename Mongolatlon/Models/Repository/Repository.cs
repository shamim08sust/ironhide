using Mongolatlon.Models.Entities;
using Mongolatlon.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Mongolatlon.Models.Repository
{
    public class Repository<K> : IRepository<K> where K : MongoEntity
    {
        public MongoServer mongoServer;
        protected MongoDatabase mDb;
        protected MongoCollection<K> Mcollection;

        public Repository(string conn, string dbname, string collectionname)
        {
            MongoClient mongocl = new MongoClient(conn);
            mongoServer = mongocl.GetServer();
            mDb = mongoServer.GetDatabase(dbname);
            Mcollection = mDb.GetCollection<K>(collectionname);
        }


        public ObjectId Insert(K item)
        {
            return Mcollection.Insert(item).Ok ? item.Id : ObjectId.Empty;
        }

        public IEnumerable<K> Find(QueryDocument document)
        {
           

           // Mcollection.EnsureIndex("loc", "2d"); 

            //mDb.RunCommand({ geoNear: "places",
            //     near: [ -74, 40.74 ],
            //     spherical: true
            //   })
           

            return Mcollection.Find(document);
        }

        public IEnumerable<K> FindAll()
        {
            return Mcollection.FindAll();
        }

        public ObjectId put(K item)
        {
            return Mcollection.Insert(item).Ok ? item.Id : ObjectId.Empty;
        }
        public IEnumerable<K> search(QueryDocument document)
        {
            
            return Mcollection.Find(document);
        }
       
    }
}