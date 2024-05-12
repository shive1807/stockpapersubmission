using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum RoundResults{
    PlayerWon = 1,
    Tie = 0,
    OpponentWon = -1,
    TimeUp = -2
}
public class GameManager : MonoBehaviour
{
    [Header ("Broadcasting To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;

    [Header("Listening To")]
    [SerializeField] InputEventChannel RoundResultChannel;

    private void Start(){
        GameResetChannel.RaiseEvent(true);
        InitRound();
    }
    private void InitRound() => GameRoundChannel.RaiseEvent(true);
    private void OnEnable() => RoundResultChannel.ActionTriggered += OnRoundResult;


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
        StartCoroutine(NextRound());
    }

    private IEnumerator GoToHomeScreen(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator NextRound(){
        yield return new WaitForSeconds(2f);
        GameRoundChannel.RaiseEvent(true);
    }
}
