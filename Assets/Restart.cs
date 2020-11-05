using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
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

    public void OnMainMenu()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            RestartGame();
            Player.axe.SetActive(false);
            Player.sword.SetActive(false);
            Player.tree.SetActive(true);
            Player.hasLoaded = true;
            _mainMenu.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "Cave Front")
        {
            CompleteRestartGame();
            _mainMenu.SetActive(true);
        }
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

        _blueSlime.transform.position = new Vector3(-25.43f, -22.83f, 0);
        _blueSlime2.transform.position = new Vector3(7.33f, -30.79f, 0);
        _blueSlime3.transform.position = new Vector3(39.39f, -32.09f, 0);
        _greenSlime.transform.position = new Vector3(-12.04f, -26.24f, 0);
        _greenSlime2.transform.position = new Vector3(16.28f, -27.33f, 0);
        _orangeSlime.transform.position = new Vector3(7.42f, -22.83f, 0);
        _orangeSlime2.transform.position = new Vector3(44.75f, -22.83f, 0);
    }
}
