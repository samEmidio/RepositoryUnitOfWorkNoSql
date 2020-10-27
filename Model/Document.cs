using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RepositoryUnitOfWorkNoSql.Model
{
    public class Document
    {
         [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = ObjectId.GenerateNewId().ToString();

        public DateTime createdAt => new ObjectId(id).CreationTime;
    }
}