using UnityEngine;
using System.Collections;

public class EnemyInformation : MonoBehaviour {
    
    public static string EnemyName                  { get; set; }
    public static BaseCharacterClass EnemyClass     { get; set; }
    public static int EnemyLevel                    { get; set; }
    public static int Strength                      { get; set; }
    public static int Stamina                       { get; set; }
    public static int Spirit                        { get; set; }
    public static int Intellect                     { get; set; }
    public static int Overpower                     { get; set; }
    public static int Luck                          { get; set; }
    public static int Armor                         { get; set; }
    public static int Mastery                       { get; set; }
    public static int Charisma                      { get; set; }

    public static float EnemyMaxHealth    { get; set; }
    public static float EnemyHealth       { get; set; }
    public static float EnemyMaxEnergy    { get; set; }
    public static float EnemyEnergy       { get; set; }
}
