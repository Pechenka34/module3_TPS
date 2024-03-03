using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private float _fallVelocity = 0;

    private Vector3 _moveVector;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator.SetBool("IsGrounded", true);
    }

    void Update()
    {
        // movement

        _moveVector = Vector3.zero;
        if (_characterController.isGrounded)
        {
            _animator.SetBool("IsRun", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("IsRun", true);
            _moveVector += transform.forward;
        }  
        
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            _animator.SetBool("IsRun", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            _animator.SetBool("IsRun", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            _animator.SetBool("IsRun", true);
        }

        // jump
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // movement
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        GetComponent<CharacterController>().Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // stop keep falling if on the ground
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
