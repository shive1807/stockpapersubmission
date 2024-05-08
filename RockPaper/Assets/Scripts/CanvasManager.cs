using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;


    private void OnEnable(){
        GameResetChannel.ActionTriggered += ResetCanvas;
    }   

    private void OnDisable(){
        GameResetChannel.ActionTriggered -= ResetCanvas;
    }

    private void ResetCanvas(bool reset = default){
    }
}
