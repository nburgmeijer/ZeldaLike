using System;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private string _signText = "placeholder";
    private void OnTriggerEnter2D(Collider2D collision)
     {
        EventManager<SignEnterEventInfo>.InvokeEvent(new SignEnterEventInfo() { signInfo = _signText });
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EventManager<SignExitEventInfo>.InvokeEvent(new SignExitEventInfo());
    }
}
