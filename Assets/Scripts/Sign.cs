using UnityEngine;
//this script is attatched to whatever is triggering the event

public class Sign : MonoBehaviour
{
    [SerializeField] private string _signText = "placeholder";
    //test script to invoke the some events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager<SignEnterEventInfo>.InvokeEvent(new SignEnterEventInfo() { signInfo = _signText });
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EventManager<SignExitEventInfo>.InvokeEvent(new SignExitEventInfo());
    }
}
