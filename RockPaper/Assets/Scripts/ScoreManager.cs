using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI score;
    private int ScoreCount;

    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameResetChannel;
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameOverChannel;

    private void Start(){
        score = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable(){
        GameResetChannel.ActionTriggered    += OnReset;
        GameRoundChannel.ActionTriggered    += OnRoundChanged;
        GameOverChannel.ActionTriggered     += OnGameOver;
    }

    private void OnDisable(){
        GameResetChannel.ActionTriggered    -= OnReset;
        GameRoundChannel.ActionTriggered    -= OnRoundChanged;
        GameOverChannel.ActionTriggered     -= OnGameOver;
    }

    private void OnReset(bool reset = default){
        ScoreCount = 0;
        UpdateText();
    }
    private void OnRoundChanged(bool success = default)
    {
        ScoreCount++;
        UpdateText();
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