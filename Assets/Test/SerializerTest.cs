using Entitas.Plugins.EntitySerializer;
using MongoDB.Bson;
using UnityEngine;

public class SerializerTest : MonoBehaviour {

    PlayerContext playerContext;
    // Use this for initialization
    // this test script is creating  & serializing a player entity
    IEntitySerializationService serializationService;

    EntityDocument entityDocument;
    string entityJson;

    void Start()
    {

        playerContext = Contexts.sharedInstance.player;
        serializationService = new EntitySerializationService();

        PlayerEntity e = playerContext.CreateEntity();
        e.AddHealth(100);
        e.AddUser("userID12345", "SatanIsEverywhere", "satan@hellsparadise.com");
        //as this flag Component got a [DontPersistComponent] attribute it is opted out from serialization
        e.isTest = true;

        //serialize this entity to Json by using the new generic entity serializer
        entityJson = serializationService.SerializeEntityToJson(e);
        Debug.Log("Serialized Player Entity: " + entityJson);

        //serialize this Entity to a EntityDocument (for easily saving it to NoSql databases like mongodb)
        entityDocument = serializationService.SerializeEntity(e);

        // Deserialize and recreate another entity by using the entityDocument game state object
        PlayerEntity playerEntityCopy = playerContext.CreateEntity();

        foreach (var _component in serializationService.DeserializeEntity(playerContext.contextInfo.name, entityDocument))
        {
            playerEntityCopy.ReplaceComponent(_component.Key, _component.Value);
        }
        // Deserialize and recreate another entity by using the game state as json string
        PlayerEntity playerEntityJsonCopy = playerContext.CreateEntity();

        foreach (var _component in serializationService.DeserializeEntityFromJson(playerContext.contextInfo.name, entityJson))
        {
            playerEntityJsonCopy.ReplaceComponent(_component.Key, _component.Value);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
