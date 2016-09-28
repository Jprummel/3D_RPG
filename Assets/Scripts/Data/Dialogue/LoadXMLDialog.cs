using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class LoadXMLDialog : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLines;
	// Use this for initialization
	void Start () {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetDialog()
    {

    }
}
