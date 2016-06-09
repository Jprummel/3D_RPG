using UnityEngine;
using System.Collections;

public class CreateNewScroll : MonoBehaviour {

    private BaseScroll _newScroll;
	// Use this for initialization
	void Start () {
        CreateScroll();
        Debug.Log(_newScroll.ItemName);
        Debug.Log(_newScroll.ItemDescription);
        Debug.Log(_newScroll.ItemID.ToString());
        Debug.Log(_newScroll.SpellEffectID.ToString());
	}

    private void CreateScroll()
    {
        _newScroll = new BaseScroll();
        _newScroll.ItemName = "Scroll";
        _newScroll.ItemDescription = "A powerful scroll filled with knowledge";
        _newScroll.ItemID = Random.Range(1, 101);
        _newScroll.SpellEffectID = Random.Range(500, 1001);
    }
}
