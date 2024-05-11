using System;
using UnityEngine;
using UnityEngine.UI;

public enum Moves{
    Stone,
    Paper,
    Scissors,
    Lizard,
    Spock
}

public class TurnManager : MonoBehaviour
{
    private bool turnPlayed;
    private bool isTimeUp;
    private Button[] moves;

    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;
    [SerializeField] InternalEventChannel GameSwitchTurnChannel;
    [SerializeField] InternalEventChannel GameTimerChannel;


    private void OnEnable()
    {
        GameResetChannel.ActionTriggered += ResetTurn;
        GameRoundChannel.ActionTriggered += RoundOver;
        GameOverChannel.ActionTriggered += GameOver;
        GameSwitchTurnChannel.ActionTriggered += SwitchTurn;
        GameTimerChannel.ActionTriggered += TimerStatus;
    }
    private void OnDisable()
    {
        GameResetChannel.ActionTriggered -= ResetTurn;
        GameRoundChannel.ActionTriggered -= RoundOver;
        GameOverChannel.ActionTriggered -= GameOver;
        GameSwitchTurnChannel.ActionTriggered -= SwitchTurn;
        GameTimerChannel.ActionTriggered -= TimerStatus;
    }

    private void TimerStatus(bool timeUp)
    {

    }
    private void SwitchTurn(bool success = default)
    {

    }

    private void ResetTurn(bool reset = default)
    {
        moves = new Button[Constants.MOVES];

        moves = transform.GetChild(0).GetComponentsInChildren<Button>();

        SetControlsInteractable(false);
    }

    private void RoundOver(bool success = default)
    {

    }

    private void GameOver(bool success = default)
    {

    }

    private void SetControlsInteractable(bool state)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            moves[i].interactable = state;
        }
    }
}