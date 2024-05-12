using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InputEventChannel RoundResultChannel;
    [SerializeField] private TMPro.TextMeshProUGUI FeedbackText;

    private void OnEnable(){
        GameResetChannel.ActionTriggered += OnGameReset;
        GameRoundChannel.ActionTriggered += OnGameRoundChange;
        RoundResultChannel.ActionTriggered += OnRoundResult;
    }

    private void OnDisable(){
        GameResetChannel.ActionTriggered -= OnGameReset;
        GameRoundChannel.ActionTriggered -= OnGameRoundChange;
        RoundResultChannel.ActionTriggered -= OnRoundResult;
    }

    private void OnGameReset(bool reset = false){
        FeedbackText.text = "";
    }

    private void OnGameRoundChange(bool reset = false){
        FeedbackText.text = "Please select a move";
        FeedbackText.color = Color.black;
    }

    private void OnRoundResult(int result){
        if(result.Equals((int)RoundResults.PlayerWon)){
            FeedbackText.text = "YOU WIN, +1";
            FeedbackText.color = Color.green;
        }else if(result.Equals((int)RoundResults.Tie))
        {
            FeedbackText.text = "TIE";
            FeedbackText.color = Color.white;
        }else if(result.Equals((int)RoundResults.OpponentWon))
        {
            FeedbackText.text = "CPU Wins, Game Over";
            FeedbackText.color = Color.red;
        }else{
            FeedbackText.text = "Time Out, Game Over";
            FeedbackText.color = Color.red;
        }
    }
}
