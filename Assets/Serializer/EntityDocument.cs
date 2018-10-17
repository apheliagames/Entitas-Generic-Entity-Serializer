using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entitas.Plugins.EntitySerializer
{
    public class EntityDocument
    {
        [BsonId][BsonRepresentation(BsonType.String)][IgnoreComponent]
        public ObjectId _id;
        [IgnoreComponent]
        public string userID;
        [BsonExtraElements]
        public BsonDocument entityData;
    }
}

