using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;

namespace Entitas.Plugins.EntitySerializer
{
    public class EntitySerializationService : IEntitySerializationService
    {        
        Contexts contexts;
        public EntitySerializationService()
        {
            contexts = Contexts.sharedInstance;
        }

        public EntityDocument SerializeEntity(IEntity entity)
        {
            EntityDocument _entityDocument = new EntityDocument();
            _entityDocument.entityData = new BsonDocument();

            foreach (IComponent _component in entity.GetComponents())
            {
                if (!_component.GetType().IsDefined(typeof(DontPersistComponent), false))
                    _entityDocument.entityData.Add(new BsonElement(_component.GetType().Name.RemoveComponentSuffix(), _component.ToBsonDocument(_component.GetType())));
            }
            return _entityDocument;
        }

        public Dictionary<int, IComponent> DeserializeEntity(string contextID, EntityDocument entityDocument)
        {
            IContext _context = Array.Find(contexts.allContexts, c => c.contextInfo.name == contextID);

            Dictionary<int, IComponent> _components = new Dictionary<int, IComponent>();            

            foreach (BsonElement _element in entityDocument.entityData)
            {               
                int _componentIndex = Array.IndexOf(_context.contextInfo.componentNames, _element.Name);
                IComponent _component = (IComponent)BsonSerializer.Deserialize(_element.Value.AsBsonDocument, _context.contextInfo.componentTypes[_componentIndex]);                
                _components.Add(_componentIndex, _component);
            }
            return _components;
        }        
        
        public string SerializeEntityToJson(IEntity entity)
        {
            return SerializeEntity(entity).ToJson();
        }
        public Dictionary<int, IComponent> DeserializeEntityFromJson(string contextID, string entityJson)
        {
            EntityDocument _document = BsonSerializer.Deserialize<EntityDocument>(entityJson);
            return DeserializeEntity(contextID, _document);
        }
    }
}

