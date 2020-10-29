using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] Dialogue _startingDialogue;

    void Awake()
    {
        _runtimeData.CurrentGameplayState = GameplayState.InDialog;
    }

    // Start is called before the first frame update
    void Start() 
    {
        GameEvents.InvokeDialogInitiated(_startingDialogue);    
    }
}
