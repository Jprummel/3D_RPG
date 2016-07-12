using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInformation : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public static List<BaseAbility>     PlayersAbilities;

    public static bool                  IsMale          { get; set; }
    public static string                PlayerBio       { get; set; }
    public static BaseEquipment         EquipmentOne    { get; set; }
    public static string                PlayerName      { get; set; }
    public static BaseCharacterRace     PlayerRace      { get; set; }
    public static BaseCharacterClass    PlayerClass     { get; set; }
    public static int                   PlayerLevel     { get; set; }
    public static int                   Strength        { get; set; }
    public static int                   Stamina         { get; set; }
    public static int                   Spirit          { get; set; }
    public static int                   Intellect       { get; set; }
    public static int                   Overpower       { get; set; }
    public static int                   Luck            { get; set; }
    public static int                   Armor           { get; set; }
    public static int                   Mastery         { get; set; }
    public static int                   Charisma        { get; set; }
    public static int                   CurrentXP       { get; set; }
    public static int                   RequiredXP      { get; set; }
    public static int                   Gold            { get; set; }

    public static BaseAbility playerMoveOne = new AttackAbility();
    public static BaseAbility playerMoveTwo = new SwordSlash();

    public static int                   PlayerHealth    { get; set; }
    public static int                   PlayerEnergy    { get; set; }   
}
