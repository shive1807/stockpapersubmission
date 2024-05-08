using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int currentRound;

    [Header ("Broadcasting To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;
    [SerializeField] InternalEventChannel GameSwitchTurnChannel;

    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameTimerChannel;

    private void Start(){
        currentRound = 0;

        GameResetChannel.RaiseEvent(true);
    }
    private void InitRound(){

    }

}
