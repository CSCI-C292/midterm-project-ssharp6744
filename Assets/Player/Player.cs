using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Animator _animator;
    [SerializeField] RuntimeData _runtimeData;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    static Vector3 playerPos = new Vector3(33, 28, 1);

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            transform.position = playerPos - new Vector3(0, 1, 0); 
        }

        if (playerPos == transform.position)
        {
            GameObject.Find("DialogueUI").GetComponent<Canvas>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movement code taken from: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
        {
            Movement();    
        }
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

    void OnTriggerEnter2D(Collider2D other) 
    { 
        _runtimeData.CurrentGameplayState = GameplayState.FreeWalk;

        if (other.name == "Exit")
        {
            SceneManager.LoadScene("SampleScene"); 
            DontDestroyOnLoad(GameObject.Find("Canvas"));  
        }

        if (other.name == "Stone Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Stone House"); 
        }

        if (other.name == "Purple Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Purple House");
            DontDestroyOnLoad(GameObject.Find("Canvas"));
        }   

        if (other.name == "Green Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Green House");
        } 

        if (other.name == "Blue Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Blue House");
        }  

        if (other.name == "Cave Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Cave Front");
        } 

        if (other.name == "Forest Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Old Man's Cave");
        }

        if (other.name == "Open Door")
        {
            playerPos = transform.position;
            SceneManager.LoadScene("Cave Back");
        }       
    }
}
