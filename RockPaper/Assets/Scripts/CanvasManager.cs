using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameManagerResetEvent;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;


    private void OnEnable(){
        GameManagerResetEvent.ActionTriggered += Reset;
    }   

    private void OnDisable(){
        GameManagerResetEvent.ActionTriggered -= Reset;
    }

    private void Reset(bool reset = false){

    }


}
