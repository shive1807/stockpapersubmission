using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Image FillerImage;
    [SerializeField] private TMPro.TextMeshProUGUI TimerText;
    [SerializeField] private TMPro.TextMeshProUGUI TimeOutText;

    private float currentTimer = 0.0f;

    [Header("Broadcasting To")]
    [SerializeField] InputEventChannel RoundResultChannel;
    
    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameRoundChannel;
    [SerializeField] InternalEventChannel GameResetChannel;

    private void OnEnable(){
        GameRoundChannel.ActionTriggered += OnRoundStarts;
        GameResetChannel.ActionTriggered += OnGameReset;
    }

    private void OnDisable(){
        GameRoundChannel.ActionTriggered -= OnRoundStarts;
        GameResetChannel.ActionTriggered -= OnGameReset;
    }

    private void OnRoundStarts(bool start = false){
        currentTimer = Constants.RoundTimerValue;
        ResetTimer();
        StartCoroutine(TurnTimerOn());
        Debug.Log("On Round Starts");
    }

    private void OnGameReset(bool reset = false){
        if(reset){
            TimeOutText.gameObject.SetActive(false);
        }
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
        TimerText.text = currentTimer.ToString();
        FillerImage.fillAmount = 1.0f;
    }
}
