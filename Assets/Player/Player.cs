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
    [SerializeField] Dialogue _intro;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    static Vector3 playerPos = new Vector3(33, 28, 1);
    static string newScene;
    public static GameObject sword;
    public static GameObject axe;
    public static int health = 3;

    void Awake() 
    {
        if (SceneManager.GetActiveScene().name != "SampleScene")
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        sword = GameObject.Find("Sword");
        axe = GameObject.Find("Axe");

        sword.SetActive(false);
        axe.SetActive(false);

        GameEvents.InvokeDialogInitiated(_intro);
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().name != "SampleScene")
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
        if (other.name == "Exit")
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(newScene));
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            transform.position = playerPos - new Vector3(0, 1, 0); 
        }

        if (other.name == "Stone Door")
        {
            newScene = "Stone House";
            LoadNewScene(newScene);
        }

        if (other.name == "Purple Door")
        {
            newScene = "Purple House";
            LoadNewScene(newScene);
        }   

        if (other.name == "Green Door")
        {
            newScene = "Green House";
            LoadNewScene(newScene);
        } 

        if (other.name == "Blue Door")
        {
            newScene = "Blue House";
            LoadNewScene(newScene);
        }  

        if (other.name == "Cave Door")
        {
            newScene = "Cave Front";
            LoadNewScene(newScene);
        } 

        if (other.name == "Forest Door")
        {
            newScene = "Old Man's Cave";
            LoadNewScene(newScene);
        }

        if (other.name == "Open Door")
        {
            newScene = "Cave Back";
            LoadNewScene(newScene);
        }      
    }

    void LoadNewScene(string scene)
    {
        playerPos = transform.position;
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        transform.position = GameObject.Find("PlayerStart").transform.position;
    }
}
