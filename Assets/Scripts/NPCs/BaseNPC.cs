using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseNPC : MonoBehaviour {

    
    [SerializeField]private GameObject _overheadPanel;
    [SerializeField]private GameObject _npcModel;
    [SerializeField]private Text _npcNamePlate;    
    [SerializeField]private GameObject _dialogueCanvas;
    public string NPCName { get; set; }
    public string NPCTag { get; set; }
    private GameObject _player;
    public enum NPCType
    {
        NORMAL,
        QUESTGIVER,
        SHOP
    }

    public NPCType NpcType { get; set; }

	void Start () {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        _npcNamePlate.text = NPCName + "\n" + "<" + NPCTag + ">";
        _npcNamePlate = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        CheckForPlayer();
	}

    void CheckForPlayer()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position ) < 15f)
        {
            _overheadPanel.SetActive(true);
            _npcModel.transform.LookAt(_player.transform);
            if (Input.GetKey(KeyCode.F))
            {
                
            }
        }
        else
        {
            _overheadPanel.SetActive(false);
        }
    }


}
