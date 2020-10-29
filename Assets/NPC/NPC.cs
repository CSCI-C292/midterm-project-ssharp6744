﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue _dialog;
    [SerializeField] Dialogue _hearFox;
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
               //GameObject.Find("Axe").SetActive(true);
               //hasTalkedToGirl = true;
               Player.axe.SetActive(true);
           }

           if (_dialog.name == "House Sign")
           {
               //GameObject.Find("Sword").SetActive(true);
               //hasTalkedToSign = true;
               Player.sword.SetActive(true);
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
