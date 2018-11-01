using Entitas;
using Entitas.CodeGeneration.Attributes;

[Player][Stored]
public class UserComponent : IComponent
{
    public string userID;
    public string userName;
    public string email;    
}