using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentRound;

    [Header ("Broadcasting To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;

    private void StartGame(){
        currentRound = 0;

    }
    private void InitRound(){

    }

}
