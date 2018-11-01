using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entitas.Plugins.EntitySerializer
{
    public class EntityDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id;        
        public string userID;
        [BsonExtraElements]
        public BsonDocument entityData;
    }
}

