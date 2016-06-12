using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    
    //Transforms
    [SerializeField]private Transform _target;
    [SerializeField]private Transform _camTransform;

    private Camera _cam;
    
    //Floats
    [SerializeField]private float _yAngleMin;
    [SerializeField]private float _yAngleMax;
    [SerializeField]private float _sensitivityX;
    [SerializeField]private float _sensitivityY;
    [SerializeField]private float _distance;
    [SerializeField]private float _damping;
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;
    
    private float _x;
    private float _y;
    

    //Vector
    private Vector3 _cameraForward;
    public Vector3 CameraForward
    {
        get { return _cameraForward; }
    }
	
    // Use this for initialization
	void Start () 
    {
        _camTransform = transform;
        _cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        CameraRotation();
        FollowPlayer();

	}

    void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -_distance);
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
        _camTransform.position = _target.position + rotation * direction;

        _camTransform.LookAt(_target.position);
    }

    private void FollowPlayer()
    {
        //Move the camera smoothly to the position of the player and gives the normalized camera forward as a Vector3
        if (_target.position != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _damping);
        }

        _cameraForward = transform.TransformDirection(Vector3.forward);
        _cameraForward.y = 0f;
        _cameraForward = _cameraForward.normalized;
    }

    public void GetCameraInput(float x, float y)
    {
        _x = x;
        _y = y;
    }

    void CameraRotation()
    {
        _currentX += _x * _sensitivityX;
        _currentY += _y * _sensitivityY;

        _currentY = Mathf.Clamp(_currentY, _yAngleMin, _yAngleMax);
    }
}
