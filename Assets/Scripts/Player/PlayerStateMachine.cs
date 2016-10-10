using UnityEngine;
using System.Collections;

public class PlayerStateMachine : MonoBehaviour {

    public enum PlayerState
    {
        IDLE,
        MOVING,
        TALKING
    }

    public PlayerState currentPlayerState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentPlayerState)
        {
            case(PlayerState.IDLE):
                break;
            case(PlayerState.MOVING):
                break;
            case(PlayerState.TALKING):
                break;
        }
	}
}
