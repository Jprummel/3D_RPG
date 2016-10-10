using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour{

    [SerializeField]public GameObject model;
    public string Name;
    public string Description;
    public int Level;
    public int Strength;
    public int Stamina;
    public int Spirit;
    public int Intellect;
    public int Armor;
    public int Overpower;
    public int Luck;
    public int Mastery;
    public int Charisma;

    public float Health;
    public float MaxHealth;
    public float Mana;
    public float MaxMana;

}
