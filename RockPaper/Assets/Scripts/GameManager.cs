using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{
    Start, 
    Playing,
    End
}
public enum RoundResults{
    PlayerWon = 1,
    Tie = 0,
    OpponentWon = -1,
    TimeUp = -2
}
public class GameManager : Singleton<GameManager>
{

    private GameState state;

    [Header ("Broadcasting To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;

    [Header("Listening To")]
    [SerializeField] InputEventChannel RoundResultChannel;

    private void Start(){
        state = GameState.Start;
        GameResetChannel.RaiseEvent(true);
        InitRound();
    }
    private void InitRound(){
        state = GameState.Playing;
        GameRoundChannel.RaiseEvent(true);
    }
    private void OnEnable(){
        RoundResultChannel.ActionTriggered += OnRoundResult;
    }
    private void OnDisable(){
        RoundResultChannel.ActionTriggered -= OnRoundResult;
    }
    /********************************************************************
    **************************GAME LOGIC*********************************
    *********************************************************************/
    private void OnRoundResult(int result){
        if(result == -1 || result == -2){
            StartCoroutine(GoToHomeScreen());//call game over and move to home screen.
            return;
        }
        GameRoundChannel.RaiseEvent(true);
    }

    private IEnumerator GoToHomeScreen(){
        yield return new WaitForSeconds(1f);
        // SceneManager.LoadScene(0);
    }
}
