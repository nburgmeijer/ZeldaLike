using UnityEngine;
//this script is attatched to whatever is triggering the event

public class Sign : MonoBehaviour
{
    //test script to invoke the some events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager<SignEnterEventInfo>.InvokeEvent(new SignEnterEventInfo() { signInfo = "This sign reads: Hi there!" });
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EventManager<SignExitEventInfo>.InvokeEvent(new SignExitEventInfo());
    }


}
