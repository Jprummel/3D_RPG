using UnityEngine;
using System.Collections;

public class LoadPosition : MonoBehaviour {

	void Start () {
        transform.position = GameInformation.PlayerMapPos;
	}
}
