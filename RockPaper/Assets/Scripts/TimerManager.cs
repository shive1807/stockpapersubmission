using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Image FillerImage;
    [SerializeField] private TMPro.TextMeshProUGUI TimerText;
    private float currentTimer = 0.0f;

    [Header("Broadcasting To")]
    [SerializeField] InputEventChannel RoundResultChannel;
    
    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InputEventChannel PlayerTurnChannel;

    private void OnEnable(){
        GameRoundChannel.ActionTriggered += OnRoundStarts;
        PlayerTurnChannel.ActionTriggered += OnPlayedTurn;
    }

    private void OnDisable(){
        GameRoundChannel.ActionTriggered -= OnRoundStarts;
        PlayerTurnChannel.ActionTriggered -= OnPlayedTurn;
    }

    private void OnRoundStarts(bool start = false){
        currentTimer = Constants.RoundTimerValue;
        ResetTimer();
        StartCoroutine(TurnTimerOn());
        Debug.Log("On Round Starts");
    }

    private void OnPlayedTurn(int turn)
    {
        StopAllCoroutines();
    }
    private IEnumerator TurnTimerOn(){
        Debug.Log("Round End Called");

        while (currentTimer >= 0.0f){
            yield return null;
            currentTimer -= Time.deltaTime;
            currentTimer = Mathf.Round(currentTimer * 1000.0f) / 1000.0f;
            TimerText.text = Mathf.Clamp(currentTimer, 0.0f, Constants.RoundTimerValue).ToString();
            FillerImage.fillAmount = currentTimer / Constants.RoundTimerValue;
        }
        RoundResultChannel.RaiseEvent(-2);
    }

    private void ResetTimer(){
        StopAllCoroutines();
        TimerText.text = currentTimer.ToString();
        FillerImage.fillAmount = 1.0f;
    }
}
