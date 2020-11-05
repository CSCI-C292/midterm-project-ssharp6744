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
    [SerializeField] GameObject _winText;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    static Vector3 playerPos;
    static string newScene;
    public static GameObject sword;
    public static GameObject axe;
    public static GameObject tree;
    public static int health = 3;
    public static bool hasLoaded = true;

    void Awake() 
    {   
        sword = GameObject.Find("Sword");
        axe = GameObject.Find("Axe");
        tree = GameObject.Find("Tree");
        
        sword.SetActive(false);
        axe.SetActive(false);

        playerPos = transform.position;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement code taken from: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
        {
            Movement();    
        }

        if (GameObject.Find("Main Menu") == null)
        {
            hasLoaded = false;
        }

        if (GameObject.Find("Main Menu") != null)
        {
            hasLoaded = true;
        }

        if (hasLoaded)
        {
            GameEvents.InvokeDialogInitiated(_intro);
            hasLoaded = false;
        }

        if (_runtimeData.CurrentGameplayState == GameplayState.InDialog)
        {
            _animator.SetFloat("Speed", 0);
            body.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Movement()
    {
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        
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
            transform.position = GameObject.Find("End").transform.position;
        } 
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.name == "End" && NPC.hasWon && _runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
        {
            _winText.SetActive(true);
            NPC.hasWon = false;
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
