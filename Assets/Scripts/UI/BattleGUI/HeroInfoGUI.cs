using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroInfoGUI : MonoBehaviour {

    private TurnBasedCombatStateMachine _tbs;
    [SerializeField]private GameObject _heroInfoPrefab;

    private Text _CharactersName;
    private Text _CharactersHealth;
    private Text _CharactersMana;
    private Text _CharactersLevel;

	// Use this for initialization
	void Start () {
        _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
        CharacterInfo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CharacterInfo()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            GameObject heroInfoPanel = Instantiate(_heroInfoPrefab);
            heroInfoPanel.name = "PartyMemberInfo";

            _CharactersName = heroInfoPanel.transform.FindChild("PartyMemberName").GetComponent<Text>();
            _CharactersName.text = partyMember.Name;

            _CharactersLevel = heroInfoPanel.transform.FindChild("PartyMemberLevel").GetComponent<Text>();
            _CharactersLevel.text = "Lv: " + partyMember.Level.ToString();

            _CharactersHealth = heroInfoPanel.transform.FindChild("PartyMemberHealth").GetComponent<Text>();
            _CharactersHealth.text = "HP : " + partyMember.Health.ToString() + "/" + partyMember.MaxHealth.ToString();
            _CharactersMana = heroInfoPanel.transform.FindChild("PartyMemberMana").GetComponent<Text>();
            _CharactersMana.text = "MP : " + partyMember.Mana.ToString() +"/" + partyMember.MaxMana.ToString();
            Debug.Log(partyMember.Name + partyMember.Health + "HP");

            heroInfoPanel.transform.SetParent(GameObject.FindGameObjectWithTag(Tags.PARTYPANEL).transform);
        }
    }
}
