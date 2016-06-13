using UnityEngine;
using System.Collections;

public class CameraInput : MonoBehaviour {

    private CameraController _camControl;
    private Vector2 _rotationVector;
    private float _mouseX;
    private float _mouseY;
    private float _mouseScroll;
    private bool _leftClick;
    private bool _isMoving;

	// Use this for initialization
	void Start () {
	    _camControl = GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        Inputs();
	}

    void Inputs()
    {
        _mouseX = Input.GetAxis(InputAxes.XMOUSE);
        _mouseY = Input.GetAxis(InputAxes.YMOUSE);
        _mouseScroll = Input.GetAxis(InputAxes.MOUSESCROLL);
        _leftClick = Input.GetMouseButton(0);
        if (Input.GetAxis(InputAxes.MOVEHORIZONTAL) != 0 || Input.GetAxis(InputAxes.MOVEVERTICAL) != 0)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }
        Debug.Log(_mouseScroll);
        _camControl.CheckIfPlayerMoves(_isMoving);
        _camControl.GetMousePositionInput(_mouseX, -_mouseY, _leftClick); //Rotate Camera

        
        if (_mouseScroll != 0)
        {
            _camControl.GetMouseScrollInput(_mouseScroll);
        }
        else
        {
            _camControl.GetMouseScrollInput(0);
        }
    }
}
