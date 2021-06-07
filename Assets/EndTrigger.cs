using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public HandgunScriptLPFP gameManager;

    void OnTriggerEnter(){
        gameManager.CompleteLevel();
        
    }
}
