using UnityEngine;

public class PlayerContextBubbles : MonoBehaviour
{
    [SerializeField] private GameObject _contextBubble;
    private bool _inRange = false;

    private void Awake()
    {
        EventManager<SignEnterEventInfo>.RegisterListener(OnTriggerSignEnter);
        EventManager<SignExitEventInfo>.RegisterListener(OnTriggerSignExit);
    }

    private void OnTriggerSignEnter(SignEnterEventInfo eventInfo)
    {
        _contextBubble.SetActive(true);
        _inRange = true;
    }

    private void OnTriggerSignExit(SignExitEventInfo eventInfo)
    {
        _contextBubble.SetActive(false);
        _inRange = false;
    }


    

}
