using UnityEngine;
using System.Collections;

public class CameraInput : MonoBehaviour {

    private CameraControl _camControl;
    private Vector2 _rotationVector;
    private float _mouseX;
    private float _mouseY;

	// Use this for initialization
	void Start () {
	    _camControl = GetComponent<CameraControl>();
	}
	
	// Update is called once per frame
	void Update () {
        Inputs();
	}

    void Inputs()
    {
        _mouseX = Input.GetAxis(InputAxes.XMOUSE);
        _mouseY = Input.GetAxis(InputAxes.YMOUSE);

        if (Input.GetMouseButton(1))
        {
            _camControl.GetCameraInput(_mouseX, _mouseY); //Rotate Camera
        }
        else
        {
            _camControl.GetCameraInput(0, 0); // Stop Rotating when mouse button isn't pressed
        }
    }
}
