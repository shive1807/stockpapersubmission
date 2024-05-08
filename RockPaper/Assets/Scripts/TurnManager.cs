using UnityEngine;

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

    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;
    [SerializeField] InternalEventChannel GameSwitchTurnChannel;

    private void OnEnable(){
        GameResetChannel.ActionTriggered        += ResetTurn;
        GameRoundChannel.ActionTriggered        += RoundOver;
        GameOverChannel.ActionTriggered         += GameOver;
        GameSwitchTurnChannel.ActionTriggered   += SwitchTurn;
    }
    private void OnDisable(){
        GameResetChannel.ActionTriggered        -= ResetTurn;
        GameRoundChannel.ActionTriggered        -= RoundOver;
        GameOverChannel.ActionTriggered         -= GameOver;
        GameSwitchTurnChannel.ActionTriggered   -= SwitchTurn;
    }

    private void SwitchTurn(bool success = default)
    {

    }

    private void ResetTurn(bool reset = default){

    }

    private void RoundOver(bool success = default)
    {

    }

    private void GameOver(bool success = default)
    {

    }

    
}
