using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Input Event Channel")]
public class InputEventChannel : ScriptableObject
{
    public UnityAction<int> ActionTriggered;

    public void RaiseEvent(int input)
    {
        if (!(ActionTriggered == null))
        {
            ActionTriggered.Invoke(input);
        }
        else
        {
            Debug.LogWarning("Action call back was requested, but nobody picked it up");
        }
    }
}