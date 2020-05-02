using UnityEngine;
using Cinemachine;

public class RoomSwitchEvents : MonoBehaviour
{
    #region Fields

    private CinemachineClearShot clearShot;
    private bool InvokeOnceFlag = false;

    //public delegate void BlendingStarted(Object obj);
    //public static event BlendingStarted BlendingStartedEvent;
    //public delegate void BlendingEnded(Object obj);
    //public static event BlendingEnded BlendingEndedEvent;

    #endregion

    private void Awake()
    {
        clearShot = GetComponent<CinemachineClearShot>();
    }
    
    private void Update()
    {
       
        if (clearShot.IsBlending && !InvokeOnceFlag)
        {
            InvokeOnceFlag = true;
            EventManager<BlendingStartEventInfo>.InvokeEvent(new BlendingStartEventInfo() { clearShot = clearShot }) ;
        }
        if(!clearShot.IsBlending && InvokeOnceFlag)
        {
            InvokeOnceFlag = false;
            EventManager<BlendingEndEventInfo>.InvokeEvent(new BlendingEndEventInfo() { clearShot = clearShot });
        }
    }
}
