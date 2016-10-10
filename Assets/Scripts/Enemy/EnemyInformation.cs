using UnityEngine;
using System.Collections;

public class EnemyInformation : MonoBehaviour {
    
    public static string Name                   { get; set; }
    public static BaseCharacterClass Class      { get; set; }
    public static int Level                     { get; set; }
    public static int Strength                  { get; set; }
    public static int Stamina                   { get; set; }
    public static int Spirit                    { get; set; }
    public static int Intellect                 { get; set; }
    public static int Overpower                 { get; set; }
    public static int Luck                      { get; set; }
    public static int Armor                     { get; set; }
    public static int Mastery                   { get; set; }
    public static int Charisma                  { get; set; }

    public static float MaxHealth               { get; set; }
    public static float Health                  { get; set; }
    public static float MaxEnergy               { get; set; }
    public static float Energy                  { get; set; }
}
