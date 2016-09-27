using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class BaseCharacter : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public List<BaseAbility>     Skills;
    public List<BaseAbility>     Magic;   

    public int                  Number;
    public bool                 IsMale;         
    public string               Name;   
    public BaseCharacterRace    Race;     
    public BaseCharacterClass   Class;
    public int                  Level;
    public int                  Strength;
    public int                  Stamina;
    public int                  Spirit;
    public int                  Intellect;
    public int                  Overpower;
    public int                  Luck;
    public int                  Armor;
    public int                  Mastery;
    public int                  Charisma;
    public float                CurrentXP;
    public float                RequiredXP;
    public int                  StatPoints;

    public float                MaxHealth;
    public float                Health;
    public float                MaxMana;
    public float                Mana;
}
