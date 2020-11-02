using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteRestart : MonoBehaviour
{
    [SerializeField] GameObject emptyHeart2;
    [SerializeField] GameObject emptyHeart3;
    [SerializeField] GameObject _blueSlime;
    [SerializeField] GameObject _blueSlime2;
    [SerializeField] GameObject _blueSlime3;
    [SerializeField] GameObject _greenSlime;
    [SerializeField] GameObject _greenSlime2;
    [SerializeField] GameObject _orangeSlime;
    [SerializeField] GameObject _orangeSlime2;

    public void RestartGame()
    {
        GameObject.Find("Player").transform.position = GameObject.Find("Beginning").transform.position;
        emptyHeart2.SetActive(false);
        emptyHeart3.SetActive(false);
        Player.axe.SetActive(false);
        Player.sword.SetActive(false);
        GameObject.Find("Win Screen").SetActive(false);
    }
}

