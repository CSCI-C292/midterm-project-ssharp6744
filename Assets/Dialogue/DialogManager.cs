using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;
    Dialogue _currentDialogue;
    int _currentSlideIndex = 0;

    void Awake() 
    {
        GameEvents.DialogFinished += OnDialogFinished;
        GameEvents.DialogInitiated += OnDialogInitiated;     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_currentSlideIndex < _currentDialogue.DialogSlides.Length - 1)
            {
               _currentSlideIndex++;
                ShowSlide(); 
            }

            else
            {
                GameEvents.InvokeDialogFinished();
            } 
        }
    }

    void OnDialogInitiated(object sender, DialogueEventArgs args)
    {
        _currentDialogue = args.dialogPayload;
        _currentSlideIndex = 0;
        ShowSlide();
        GetComponent<Canvas>().enabled = true;
        _runtimeData.CurrentGameplayState = GameplayState.InDialog;
    }

    void OnDialogFinished(object sender, EventArgs args)
    {
        GetComponent<Canvas>().enabled = false;
         _runtimeData.CurrentGameplayState = GameplayState.FreeWalk;
    }

    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogueText").gameObject;
        Text textComponent = textObj.GetComponent<Text>();
        textComponent.text = _currentDialogue.DialogSlides[_currentSlideIndex];
    }
}
