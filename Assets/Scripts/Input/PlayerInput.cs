using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
                    private PlayerMovement  _playerMovement;
                    private PauseGame       _pauseGame;    
                    private Vector3         _moveDirection;
                    private Vector3         _rotateDirection;
                    private float           _moveHorizontal;
                    private float           _moveVertical;
                    private float           _rotation;
                    private bool            _sprint;
                    private bool            _jump;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _pauseGame = GetComponent<PauseGame>();
    }

    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        _moveHorizontal = Input.GetAxis(InputAxes.MOVEHORIZONTAL);
        _moveVertical   = Input.GetAxis(InputAxes.MOVEVERTICAL);
        _rotation       = Input.GetAxis(InputAxes.ROTATE);
        _sprint         = Input.GetButton(InputAxes.SPRINT);
        _jump           = Input.GetButton(InputAxes.JUMP);

        _rotateDirection    = new Vector3(0,_rotation,0);
        _moveDirection      = new Vector3(_moveHorizontal, 0, _moveVertical);
        
        _playerMovement.Input(_moveDirection,_rotateDirection,_sprint,_jump);

        if (Input.GetButtonDown(InputAxes.PAUSE))
        {
            _pauseGame.PauseToggle();
        }

    }
}
