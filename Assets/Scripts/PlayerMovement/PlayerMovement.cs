using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Scripts
    private CameraController _cam;
    private CharacterController _cc;
    
    //Vectors
    private Vector3 _moveDirection;
    private Vector3 _rotateDirection;
    private Vector3 _newForward;

    //Floats
    [SerializeField]private float _defaultSpeed, _rotateSpeed;
                    private float _speed;
    
    //Bool
    private bool _isJumping;

	// Use this for initialization
	void Start () {
        _cc = GetComponent<CharacterController>();
        _speed = _defaultSpeed;
        _cam = Camera.main.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Movement();
        Rotate();
        Jump();
	}

    public void Input(Vector3 moveDirection, Vector3 rotateDirection, bool sprint, bool jump)
    {
        _moveDirection = moveDirection;
        _rotateDirection = rotateDirection;
        _isJumping = jump;

        if (_isJumping)
        {
            Debug.Log("Jumping");
        }

        if (sprint)
        {
            _speed = _defaultSpeed * 2;
        }
        else
        {
            _speed = _defaultSpeed;
        }
    }

    void Movement()
    {
        //_newForward = Vector3.Normalize(new Vector3(_moveDirection.x, 0, _moveDirection.z) * _rotateSpeed * Time.deltaTime);
        //transform.forward = _cam.CameraForward;
        _cc.Move(transform.forward * _moveDirection.z * _speed * Time.deltaTime);
        _cc.Move(transform.right * _moveDirection.x * _speed * Time.deltaTime);
        //_cc.Move(_newForward * _speed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.Rotate(_rotateDirection * _rotateSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (_cc.isGrounded && _isJumping)
        {
            _cc.Move(Vector3.up * _speed * Time.deltaTime);
        }
    }
}
