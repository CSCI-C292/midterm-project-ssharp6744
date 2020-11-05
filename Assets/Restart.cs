using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
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
        LoadAssets();
        GameObject.Find("GameOver Screen").SetActive(false);
    }

    public void CompleteRestartGame()
    {
        LoadAssets();
        Player.axe.SetActive(false);
        Player.sword.SetActive(false);
        Player.tree.SetActive(true);
        Player.hasLoaded = true;
        SceneManager.UnloadSceneAsync("Cave Front");
        GameObject.Find("Win Screen").SetActive(false);
    }

    void LoadAssets()
    {
        GameObject.Find("Player").transform.position = GameObject.Find("Beginning").transform.position;
        Player.health = 3;
        emptyHeart2.SetActive(false);
        emptyHeart3.SetActive(false);
        _blueSlime.SetActive(true);
        _blueSlime2.SetActive(true);
        _blueSlime3.SetActive(true);
        _greenSlime.SetActive(true);
        _greenSlime2.SetActive(true);
        _orangeSlime.SetActive(true);
        _orangeSlime2.SetActive(true);
    }
}
