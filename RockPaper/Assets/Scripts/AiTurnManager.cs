using UnityEngine;
using UnityEngine.UI;

public class AiTurnManager : MonoBehaviour
{
    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private Sprite[] moveIcon;
    [SerializeField] private Image AiMoveImage;

    [Header("Listening To")]
    [SerializeField] private InternalEventChannel GameResetChannel;
    [SerializeField] private InternalEventChannel GameRoundChannel;
    [SerializeField] private InputEventChannel PlayerInputChannel;

    [Header("Broadcasting To")]
    [SerializeField] private InputEventChannel RoundResultChannel;
    [SerializeField] private InputEventChannel AiInputChannel;


    private void OnEnable(){
        GameResetChannel.ActionTriggered    += ResetTurn;
        PlayerInputChannel.ActionTriggered  += OnPlayerInput;
        GameRoundChannel.ActionTriggered    += OnRoundStarts;
    }
    private void OnDisable(){
        GameResetChannel.ActionTriggered    -= ResetTurn;
        PlayerInputChannel.ActionTriggered  -= OnPlayerInput;
        GameRoundChannel.ActionTriggered    -= OnRoundStarts;
    }

    private void ResetTurn(bool reset = default) => ResetDefault();
    private void OnRoundStarts(bool success = default) => ResetDefault();

    private void ResetDefault(){
        AiMoveImage.sprite = defaultIcon;
    }
    /********************************************************************
    **************************MAKE AI TURN*******************************
    *********************************************************************/
    private void OnPlayerInput(int input){
        var cpuTurn = PlayCPUTurn();
        AiMoveImage.sprite = moveIcon[cpuTurn];
        RoundLogicResult(input, cpuTurn);
    }
    private int PlayCPUTurn()//Controll the opponent randomness from here.
    {
        int movePlayed = Random.Range(0, 5);
        return movePlayed;
    }
    /********************************************************************
    **************************CORE GAME LOGIC****************************
    *********************************************************************/
    readonly int[,] results = new int[,] {
    {  0,  1, -1, -1,  1 },  // Rock
    { -1,  0,  1,  1, -1 },  // Paper
    {  1, -1,  0, -1,  1 },  // Scissors
    {  1, -1,  1,  0, -1 },  // Lizard
    { -1,  1, -1,  1,  0 }   // Spock
};

    private void RoundLogicResult(int playerMove, int cpuMove)
    {
        // Debug.Log(playerMove + " pm " + cpuMove + " cm");
        // Debug.Log(results[cpuMove, playerMove] + " results");
        var result = results[cpuMove, playerMove];
        RoundResultChannel.RaiseEvent(result);
        // if (result == 0)
        // {
        //     Debug.Log("Tie");
        // }
        // else if (result == -1)
        // {
        //     Debug.Log("CPU wins");
        // }
        // else if (result == -1)
        // {
        //     Debug.Log("Time Out");
        // }
        // else
        // {
        //     Debug.Log("Player wins");
        // }
    }
}   
