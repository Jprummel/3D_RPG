using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]private Transform _cameraTarget;
    private float _x = 0.0f;
    private float _y = 0.0f;
    //Mouse Locations
    private float _mouseX;
    private float _mouseY;
    private float _mouseScroll;
    //Rotate Speeds
    private int _mouseXSpeedMod = 5;
    private int _mouseYSpeedMod = 3;
    //Zoom & Distance
    [SerializeField]private float _maxViewDistance; //Max Zoom out
    [SerializeField]private float _minViewDistance; //Max Zoom in
    [SerializeField]private int _zoomRate;          //Zoom speed
    [SerializeField]private int _lerpRate = 10;
    private float _distance = 4;                    //starting distance away from player
    private float _desiredDistance;                 //used for calculations
    private float _correctedDistance;               //used for calculations
    private float _currentDistance;
    //Input Checks
    private bool _leftClick;
    private bool _isMoving;
    //
    [SerializeField]private float _cameraTargetHeight;
    


	// Use this for initialization
	void Start () {
        Vector3 angles = transform.eulerAngles;
        _x = angles.x;
        _y = angles.y;

        _currentDistance = _distance;
        _desiredDistance = _distance;
        _correctedDistance = _distance;
	}

    void LateUpdate()
    {
        CameraRotation();
        _y = ClampAngle(_y, -50, 80);

        Quaternion rotation = Quaternion.Euler(_y,_x,0);

        CameraZoom();
        _desiredDistance = Mathf.Clamp(_desiredDistance, _minViewDistance, _maxViewDistance);
        _correctedDistance = _desiredDistance;
        Vector3 position = _cameraTarget.position - (rotation * Vector3.forward * _desiredDistance);
        
        

        RaycastHit collisionHit;
        Vector3 cameraTargetPosition = new Vector3(_cameraTarget.position.x,_cameraTarget.position.y + _cameraTargetHeight, _cameraTarget.position.z);
        bool isCorrected = false;
        if (Physics.Linecast(cameraTargetPosition,position, out collisionHit))
        {
            position = collisionHit.point;
            _correctedDistance = Vector3.Distance(cameraTargetPosition, position);
            isCorrected = true;
        }

        _currentDistance = !isCorrected || _correctedDistance > _currentDistance ? Mathf.Lerp(_currentDistance, _correctedDistance, Time.deltaTime * _zoomRate) : _correctedDistance;

        position = _cameraTarget.position -(rotation * Vector3.forward * _currentDistance + new Vector3(0,-_cameraTargetHeight,0));

        transform.rotation = rotation;
        transform.position = position;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    public void GetMousePositionInput(float x, float y, bool leftClick)
    {
        _mouseX = x;
        _mouseY = y;
        _leftClick = leftClick;
    }

    public void CheckIfPlayerMoves(bool moving)
    {
        _isMoving = moving;
    }

    public void GetMouseScrollInput(float mouseScroll)
    {
        _mouseScroll = mouseScroll;
    }

    void CameraRotation()
    {
        if (_leftClick)
        {
            _x += _mouseX * _mouseXSpeedMod;
            _y += _mouseY * _mouseYSpeedMod;
        }
        else if (_isMoving)
        {
            float targetRotationAngle = _cameraTarget.eulerAngles.y;
            float cameraRotationAngle = transform.eulerAngles.y;
            _x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, _lerpRate * Time.deltaTime);
        }
    }

    void CameraZoom()
    {
        _desiredDistance    -= _mouseScroll * Time.deltaTime * _zoomRate * Mathf.Abs(_desiredDistance);
        
    }
}
