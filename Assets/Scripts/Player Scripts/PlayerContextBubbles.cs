using UnityEngine;

public class PlayerContextBubbles : MonoBehaviour
{
    [SerializeField]
    private GameObject contextBubble;
    private bool inRange = false;


    private void Start()
    {
        EventManager<SignEnterEventInfo>.RegisterListener(OnTriggerSignEnter);
        EventManager<SignExitEventInfo>.RegisterListener(OnTriggerSignExit);
    }

    private void OnTriggerSignEnter(SignEnterEventInfo eventInfo)
    {
        contextBubble.SetActive(true);
        inRange = true;
    }

    private void OnTriggerSignExit(SignExitEventInfo eventInfo)
    {
        contextBubble.SetActive(false);
        inRange = false;
    }


    

}
