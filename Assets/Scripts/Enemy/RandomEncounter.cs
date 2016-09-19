using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour {

    private PlayerMovement _movement;
    private SceneInformation _encounterAreaCheck;
	// Use this for initialization
	void Start () {
        _movement = GetComponent<PlayerMovement>();
        _encounterAreaCheck = GameObject.FindGameObjectWithTag("EncounterAreaChecker").GetComponent<SceneInformation>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForEncounter();
	}

    private void CheckForEncounter()
    {
        if (_movement.isMoving && _encounterAreaCheck.isEncounterArea)
        {
            int encounterChance = Random.Range(1, 1000);
            if (encounterChance <= 5)
            {
                GameInformation.PlayerMapScene = Application.loadedLevelName;
                GameInformation.PlayerMapPos = transform.parent.position;
                Debug.Log(GameInformation.PlayerMapScene);
                SceneManager.LoadScene("BattleScene");
            }
        }
    }
}
