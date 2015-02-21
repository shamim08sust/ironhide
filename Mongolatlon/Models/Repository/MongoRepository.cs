using Mongolatlon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace Mongolatlon.Models.Repository
{
    public class MongoRepository<K> : Repository<K> where K : MongoEntity
    {
        public MongoRepository(string collectionname)
            : base(ConfigurationManager.ConnectionStrings["Mongoconn"].ConnectionString, GetDbNameFromConnectionString(ConfigurationManager.ConnectionStrings["Mongoconn"].ConnectionString), collectionname)
        {

        }

        public static string GetDbNameFromConnectionString(string _connectionString)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                return string.Empty;
            }
            return _connectionString.Split('/').LastOrDefault();
        }
    }
}