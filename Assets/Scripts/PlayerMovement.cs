using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D _controller = default;
    public float _runSpeed = 40f;
    public Animator _animator = default;
    float _horizontalMove = 0;
    bool _jump = false;
    bool _crouch = false;

    private void Update()
    {
       _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;

        _animator.SetFloat("xSpeed", Mathf.Abs(_horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            _jump = true;
            _animator.SetBool("isGrounded", false);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            _crouch = true;
            _animator.SetBool("isDucking", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            _crouch = false;
            _animator.SetBool("isDucking", false);
        }
    }

    public void OnLanding()
    {
        _animator.SetBool("isGrounded", true);
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }
}
