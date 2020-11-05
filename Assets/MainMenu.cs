using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _credits;

    public void OnStart()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void OnCredits()
    {
        _credits.SetActive(true);
    }

    public void OnExitCredits()
    {
        _credits.SetActive(false);
    }
}
