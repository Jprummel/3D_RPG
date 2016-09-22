using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter : MonoBehaviour {


    public static List<BaseAbility> PlayersSkills { get; set; }
    public static List<BaseAbility> PlayersMagic { get; set; }

    public static string PlayerName                 { get; set; }
    public static BaseCharacterRace PlayerRace      { get; set; }
    public static BaseCharacterClass PlayerClass    { get; set; }
    public static int PlayerLevel                   { get; set; }
    public static int Strength                      { get; set; }
    public static int Stamina                       { get; set; }
    public static int Spirit                        { get; set; }
    public static int Intellect                     { get; set; }
    public static int Overpower                     { get; set; }
    public static int Luck                          { get; set; }
    public static int Armor                         { get; set; }
    public static int Mastery                       { get; set; }
    public static int Charisma                      { get; set; }
    public static float CurrentXP                   { get; set; }
    public static float RequiredXP                  { get; set; }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
