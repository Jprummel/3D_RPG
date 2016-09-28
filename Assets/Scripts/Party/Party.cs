using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Party : MonoBehaviour {

    public List<BaseCharacter> characters;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public BaseCharacter PartyMembers(int value)
    {
        return characters[value];
    }
}
