using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject emptyHeart2;
    [SerializeField] GameObject emptyHeart3;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Player")
        {
            Player.health -= 1;
            RemoveHeart();
        }

        if (Player.health == 0)
        {
            _gameOver.SetActive(true);
        }

        if (other.name == "Sword")
        {
            transform.parent.gameObject.SetActive(false);
        } 
    }

    void RemoveHeart()
    {
        if (Player.health == 2)
        {
            emptyHeart3.SetActive(true);
        }

        if (Player.health == 1)
        {
            emptyHeart2.SetActive(true);
        }
    }
}
