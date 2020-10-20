using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Animator _animator;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement code taken from: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
        Movement();
    }

    void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float horizontalSpeed = horizontal * _moveSpeed;
        float verticalSpeed = vertical * _moveSpeed;

        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            _animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));    
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            _animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));    
        }

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            _animator.SetFloat("Speed", Mathf.Abs(verticalSpeed));
        }
    }

    void FixedUpdate() 
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        float horizontalMove = horizontal * _moveSpeed;
        float verticalMove = vertical * _moveSpeed;

        body.velocity = new Vector2(horizontalMove, verticalMove);
    }
}
