using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class GameInformation : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public static List<BaseAbility>     PlayersSkills;
    public static List<BaseAbility>     PlayersMagic;

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
    public static float                 CurrentXP       { get; set; }
    public static float                 RequiredXP      { get; set; }
    public static int                   StatPoints      { get; set; }
    public static int                   Gold            { get; set; }

    public static float                 PlayerMaxHealth { get; set; }
    public static float                 PlayerHealth    { get; set; }
    public static float                 PlayerMaxEnergy { get; set; }
    public static float                 PlayerEnergy    { get; set; }

    public static string                PlayerMapScene  { get; set; }
    public static Vector3               PlayerMapPos    { get; set; }
}
