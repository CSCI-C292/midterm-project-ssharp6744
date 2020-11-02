using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject emptyHeart2;
    [SerializeField] GameObject emptyHeart3;

    public void RestartGame()
    {
        GameObject.Find("Player").transform.position = GameObject.Find("Beginning").transform.position;
        emptyHeart2.SetActive(false);
        emptyHeart3.SetActive(false);
        GameObject.Find("GameOver Screen").SetActive(false);
    }
}
