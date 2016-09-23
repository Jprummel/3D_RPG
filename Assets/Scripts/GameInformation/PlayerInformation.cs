using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PlayerInformation : BaseCharacter {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    
    public static int                   Gold            { get; set; }
    public static string                PlayerMapScene  { get; set; }
    public static Vector3               PlayerMapPos    { get; set; }
}
