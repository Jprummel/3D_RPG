using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Party : MonoBehaviour {

    public List<BaseCharacter> partyMembers = new List<BaseCharacter>();

    public BaseCharacter PartyMembers(int value)
    {
        return partyMembers[value];
    }

}
