using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI score;
    private int ScoreCount;

    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InputEventChannel    RoundResultChannel;

    private void Start(){
        score = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable(){
        GameResetChannel.ActionTriggered   += OnReset;
        RoundResultChannel.ActionTriggered += OnRoundResult;
    }

    private void OnDisable(){
        GameResetChannel.ActionTriggered   -= OnReset;
        RoundResultChannel.ActionTriggered -= OnRoundResult;
    }

    private void OnReset(bool reset = default){
        ScoreCount = 0;
        UpdateText();
    }
    private void OnRoundResult(int result){
        if(result.Equals((int)RoundResults.PlayerWon))
        {
            Debug.Log("Score Count " + ScoreCount);
            ScoreCount++;
            UpdateText();
        }else if(result.Equals((int)RoundResults.OpponentWon) || result.Equals((int)RoundResults.TimeUp)){
            OnGameOver();
        }
    }
    private void OnGameOver(bool success = default)
    {
        var highScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE, 0);

        if(highScore < ScoreCount){//New high score
            PlayerPrefs.SetInt(Constants.HIGH_SCORE, ScoreCount);
            //Trigger an event here to show ui for new high score achieved.
        }
    }

    private void UpdateText(){
        score.text = ScoreCount.ToString();
    }
}