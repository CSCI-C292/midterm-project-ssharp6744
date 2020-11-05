using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    Transform target;
    Vector3 direction;

    // Update is called once per frame
    // Movement mostly taken from https://answers.unity.com/questions/669598/detect-if-player-is-in-range-1.html
    void Update()
    {
        if (target == null) 
            return;
        
        bool tooClose = GetComponent<CircleCollider2D>().isTrigger;

        if (tooClose)
            transform.position = Vector2.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Player") 
            target = other.transform;
            GetComponent<Rigidbody2D>().isKinematic = true;
    }
 
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.name == "Player") 
            target = null;
    }
}
