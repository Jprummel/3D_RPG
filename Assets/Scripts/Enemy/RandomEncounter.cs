using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour {

    private PlayerMovement _movement;
    private SceneInformation _encounterAreaCheck;

	void Start () {
        _movement = GetComponent<PlayerMovement>();
        _encounterAreaCheck = GameObject.FindGameObjectWithTag(Tags.ENCOUNTERAREA).GetComponent<SceneInformation>();
	}
	
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
                PlayerInformation.PlayerMapScene = Application.loadedLevelName;
                PlayerInformation.PlayerMapPos = transform.parent.position;
                Debug.Log(PlayerInformation.PlayerMapScene);
                SceneManager.LoadScene("BattleScene");
            }
        }
    }
}
