# Entitas-Generic-Entity-Serializer
Generic Serializer for Entitas using mongoDB Bson/Json Serializer

This service serializes/deserializes Entitas Entities in a generic way using mongoDBs Bson/Json serializer, so that no data classes or blueprints are needed anymore to save a composition class like ECS entity is by nature.

All components, that is not opted out for serialization (via [DontPersistComponent] attribute) can be stored either in an EntityDocument object (for saving it directly to a mongoDB database) or Json strings.
 
The Deserialization methods(Json or EntityDocument as input) returning a Dictionary(int, IComponent) object, where the int key is the index of any component from the Componentpool of a context.
So you can easily recreate all saved Components in just a single iteration using the generic AddComponent(index, Icomponent) or ReplaceComponent methods from an Entity object.

One of the main adavantages of using this serializer is, that all components are getting serialized separately in Component objects instead of a single Container class keeping all components.
This makes it possible to react with subscription protocols like DDP on every change on a single Component in the database, which saves a lot of network traffic to clients.

See the SerializerTest script for better explaination, how it has to be used.

This is a quick and dirty and early beta, but it has been tested with all .NET standard types in Components. 

