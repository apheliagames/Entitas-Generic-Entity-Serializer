using Entitas;
using Entitas.CodeGeneration.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[Player]
public class HealthComponent : IComponent
{    
    public float health;   
}