using System.Collections.Generic;

namespace Entitas.Plugins.EntitySerializer
{
    public interface IEntitySerializationService
    {
        EntityDocument SerializeEntity(IEntity entity);
        string SerializeEntityToJson(IEntity entity);
        Dictionary<int, IComponent> DeserializeEntity(string contextID, EntityDocument entityDocument);
        Dictionary<int, IComponent> DeserializeEntityFromJson(string contextID, string entityJson);
    }
}

