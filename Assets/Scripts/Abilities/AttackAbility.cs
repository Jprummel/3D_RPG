[System.Serializable]
public class AttackAbility : BaseAbility {

    public AttackAbility()
    {
        AbilityName         = "Normal Attack";
        AbilityDescription  = "A basic attack";
        AbilityID           = 1;
        AbilityPower        = 10;
        AbilityCost         = 5;
    }
}
