using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Moves{
    Stone = 0,
    Paper,
    Scissors,
    Lizard,
    Spock
}

public class TurnManager : MonoBehaviour
{
    private Button[] moves;

    [Header("Listening To")]
    [SerializeField] private InternalEventChannel   GameResetChannel;
    [SerializeField] private InternalEventChannel   GameRoundChannel;
    [SerializeField] private InputEventChannel      RoundResultChannel;
    
    [Header("Broadcasting To")]
    [SerializeField] InputEventChannel PlayerTurnPlayed;


    private void OnEnable()
    {
        GameResetChannel.ActionTriggered        += ResetTurn;
        GameRoundChannel.ActionTriggered        += OnRoundStarts;
        RoundResultChannel.ActionTriggered      += RoundResult;
    }
    private void OnDisable()
    {
        GameResetChannel.ActionTriggered        -= ResetTurn;
        GameRoundChannel.ActionTriggered        -= OnRoundStarts;
        RoundResultChannel.ActionTriggered      -= RoundResult;
    }

    private void RoundResult(int result)
    {
        if(result.Equals((int)RoundResults.TimeUp)){
            SetControlsInteractable(false);
        }
    }
    private void OnRoundStarts(bool success = default)
    {
        SetControlsInteractable(true);
    }

    private void ResetTurn(bool reset = default)
    {
        moves = new Button[Constants.MOVES];

        moves = transform.GetChild(0).GetComponentsInChildren<Button>();

        SetControlsInteractable(false);
    }
    private void SetControlsInteractable(bool state)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            moves[i].gameObject.SetActive(true);
            moves[i].interactable = state;
            if(state == true){
                moves[i].onClick.AddListener(()=>{
                    TurnPlayed();
                });
            }
        }
    }
    private void TurnPlayed(){
        var index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        PlayerTurnPlayed.RaiseEvent(index);

        for(int k = 0; k<moves.Length; k++){
            if(k.Equals(index)){
                continue;
            }
            moves[k].gameObject.SetActive(false);
        }
    }
}