using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Google.Cloud.Datastore.V1;
using Newtonsoft.Json;
using Data.Models;

namespace Repositories
{
    public class GoogleDSFPLRepository<T> : IFPLRepository<T> where T : IStorable
    {
        public void Save(T obj)
        {
            DatastoreDb db = DatastoreDb.Create("fantasyfootball-204922", "default");

            KeyFactory keyFactory = db.CreateKeyFactory(obj.Kind);
            Entity entity = new Entity
            {
                Key = keyFactory.CreateKey(obj.id),
                ["updated"] = DateTime.UtcNow,
                ["text"] = JsonConvert.SerializeObject(obj),
                ["tags"] = obj.Tags.ToArray()
            };
            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                transaction.Upsert(entity);
                CommitResponse commitResponse = transaction.Commit();
                Key insertedKey = commitResponse.MutationResults[0].Key;
                Console.WriteLine($"Inserted key: {insertedKey}");
                // The key is also propagated to the entity
                Console.WriteLine($"Entity key: {entity.Key}");
            }
        }
        
        public T Get(int id)
        {
            DatastoreDb db = DatastoreDb.Create("fantasyfootball-204922", "default");

            KeyFactory keyFactory = db.CreateKeyFactory("fpl_player");
            var result = db.Lookup(keyFactory.CreateKey(id));
            return JsonConvert.DeserializeObject<T>(result["text"].StringValue);
        }
        public List<T> Find(string[] Tags)  => throw new NotImplementedException();
    }
   
}