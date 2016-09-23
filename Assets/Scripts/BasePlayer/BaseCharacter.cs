using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class BaseCharacter : MonoBehaviour {


    public static List<BaseAbility>     CharactersSkills    { get; set; }
    public static List<BaseAbility>     CharactersMagic     { get; set; }

    public static int                   CharacterNumber     { get; set; }
    public static bool                  IsMale              { get; set; }
    public static string                CharactersName      { get; set; }
    public static BaseCharacterRace     CharactersRace      { get; set; }
    public static BaseCharacterClass    CharactersClass     { get; set; }
    public static int                   CharactersLevel     { get; set; }
    public static int                   Strength            { get; set; }
    public static int                   Stamina             { get; set; }
    public static int                   Spirit              { get; set; }
    public static int                   Intellect           { get; set; }
    public static int                   Overpower           { get; set; }
    public static int                   Luck                { get; set; }
    public static int                   Armor               { get; set; }
    public static int                   Mastery             { get; set; }
    public static int                   Charisma            { get; set; }
    public static float                 CurrentXP           { get; set; }
    public static float                 RequiredXP          { get; set; }
    public static int                   StatPoints          { get; set; }

    public static float                 CharactersMaxHealth { get; set; }
    public static float                 CharactersHealth    { get; set; }
    public static float                 CharactersMaxMana   { get; set; }
    public static float                 CharactersMana      { get; set; }

    public bool isMale = IsMale;
    public string charactersName = CharactersName;
    public BaseCharacterRace charactersRace = CharactersRace;
    public BaseCharacterClass charactersClass = CharactersClass;
    public int charactersLevel = CharactersLevel;
    public int strength = Strength;
    public int stamina = Stamina;
    public int spirit = Spirit;
    public int intellect { get; set; }
    public int overpower { get; set; }
    public int luck { get; set; }
    public int armor { get; set; }
    public int mastery { get; set; }
    public int charisma { get; set; }
    public float currentXP { get; set; }
    public float requiredXP { get; set; }
    public int statPoints { get; set; }

    public float charactersMaxHealth = CharactersMaxHealth;
    public float charactersHealth = CharactersHealth;
    public float charactersMaxMana = CharactersMaxMana;
    public float charactersMana = CharactersMana;

}
