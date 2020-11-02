using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Animator _animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && transform.parent.GetComponentInParent<SpriteRenderer>().flipX == false)
        {
            _animator.SetBool("Right", true);
            _animator.SetTrigger("Attacking");
        }

        if (Input.GetButtonDown("Fire2") && transform.parent.GetComponentInParent<SpriteRenderer>().flipX == true)
        {
            _animator.SetBool("Right", false);
            _animator.SetTrigger("Attacking");
        }
    }
}
