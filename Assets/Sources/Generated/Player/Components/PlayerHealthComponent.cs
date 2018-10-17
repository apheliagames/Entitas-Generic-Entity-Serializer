//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public HealthComponent health { get { return (HealthComponent)GetComponent(PlayerComponentsLookup.Health); } }
    public bool hasHealth { get { return HasComponent(PlayerComponentsLookup.Health); } }

    public void AddHealth(float newHealth) {
        var index = PlayerComponentsLookup.Health;
        var component = CreateComponent<HealthComponent>(index);
        component.health = newHealth;
        AddComponent(index, component);
    }

    public void ReplaceHealth(float newHealth) {
        var index = PlayerComponentsLookup.Health;
        var component = CreateComponent<HealthComponent>(index);
        component.health = newHealth;
        ReplaceComponent(index, component);
    }

    public void RemoveHealth() {
        RemoveComponent(PlayerComponentsLookup.Health);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherHealth;

    public static Entitas.IMatcher<PlayerEntity> Health {
        get {
            if (_matcherHealth == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Health);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherHealth = matcher;
            }

            return _matcherHealth;
        }
    }
}
