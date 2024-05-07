using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Network Event Channel")]
public class InternalEventChannel : ScriptableObject
{
    public UnityAction<bool> ActionTriggered;

    public void RaiseEvent(bool success = false)
    {
        if (!(ActionTriggered == null))
        {
            ActionTriggered.Invoke(success);
        }
        else
        {
            Debug.LogWarning("Action call back was requested, but nobody picked it up");
        }
    }
}