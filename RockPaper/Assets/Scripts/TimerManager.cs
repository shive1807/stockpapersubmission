using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Image FillerImage;
    [SerializeField] private TMPro.TextMeshProUGUI TimerText;
    private float currentTimer = 0.0f;

    [Header("Broadcasting To")]
    [SerializeField] InternalEventChannel GameTimerChannel;
    
    [Header("Listening To")]
    [SerializeField] InternalEventChannel GameRoundChannel;

    private void OnEnable(){
        GameRoundChannel.ActionTriggered += OnRoundStarts;
    }

    private void OnDisable(){
        GameRoundChannel.ActionTriggered -= OnRoundStarts;
    }

    private void OnRoundStarts(bool start = false){
        currentTimer = Constants.RoundTimerValue;
        ResetTimer();
        StartCoroutine(TurnTimerOn());
        Debug.Log("On Round Starts");
    }

    private IEnumerator TurnTimerOn(){
        currentTimer -= Time.deltaTime;
        yield return null;
        if (currentTimer < 0.0f){
            GameTimerChannel.RaiseEvent(true);
            Debug.Log("Round End Called");
        }
    }

    private void ResetTimer(){
        TimerText.text = currentTimer.ToString();
        FillerImage.fillAmount = 1.0f;
    }
}
