using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue _dialog;
    [SerializeField] Dialogue _hearFox;
    [SerializeField] GameObject _openDoor;
    [SerializeField] GameObject _closedDoor;
    static bool hasTalkedToWizard = false;
    static bool hasKey = true;
    public static bool hasWon = false;
    bool isInside = false;

    void Update() 
    {
        if (isInside)
        {
            if (Input.GetButtonDown("Fire2") && _hearFox == null && _dialog.name != "Cave Wall")
            {
                if (_dialog.name == "Old Man")
                {
                    hasTalkedToWizard = true;
                }

                GameEvents.InvokeDialogInitiated(_dialog);

                if (_dialog.name == "Girl")
                {
                    Player.axe.SetActive(true);
                }

                if (_dialog.name == "House Sign")
                {
                    Player.sword.SetActive(true);
                }

                if (_dialog.name == "Cave Sign")
                {
                    hasTalkedToWizard = false;
                    hasKey = false;
                    hasWon = true;
                }
            }

            if (Input.GetButtonDown("Fire2") && _dialog.name == "Cave Wall")
            {
                if (hasKey)
                {
                    _closedDoor.SetActive(false);
                    _openDoor.SetActive(true);
                }

                else
                {
                    GameEvents.InvokeDialogInitiated(_dialog);
                } 
            }

            if (Input.GetButtonDown("Fire2") && _hearFox != null)
            {
                if (hasTalkedToWizard)
                {
                    GameEvents.InvokeDialogInitiated(_hearFox);
                    hasKey = true;
                }

                else
                {
                    GameEvents.InvokeDialogInitiated(_dialog);
                }
            }   
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        isInside = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        isInside = false;
    }
}
