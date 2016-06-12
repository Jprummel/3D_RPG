using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    [SerializeField]private float _rotateSpeed;
    [SerializeField]private float _forwardSpeed;
    private CharacterController _playerController;

	// Use this for initialization
	void Start () {
        _playerController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_playerController.isGrounded)
        {

        }
	}
}
