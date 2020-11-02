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
    public static bool hasTalkedToGirl = false;
    public static bool hasTalkedToSign = false;

    void OnTriggerStay2D(Collider2D other) 
    {
        if (Input.GetButtonDown("Fire2") && _hearFox == null)
        {
           if (hasTalkedToWizard)
           {
               GameEvents.InvokeDialogInitiated(_hearFox);
           }

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

           if (_dialog.name == "Wave Wall")
           {
               _closedDoor.SetActive(false);
               _openDoor.SetActive(true);
           }
        }

        if (Input.GetButtonDown("Fire2") && _hearFox != null)
        {
            if (hasTalkedToWizard)
            {
                GameEvents.InvokeDialogInitiated(_hearFox);
            }

            else
            {
                GameEvents.InvokeDialogInitiated(_dialog);
            }
        }
    }
}
