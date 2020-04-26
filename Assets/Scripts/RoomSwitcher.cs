using UnityEngine;
using Cinemachine;

public class RoomSwitcher : MonoBehaviour
{
    #region Fields

    private CinemachineClearShot clearShot;
    private bool InvokeOnceFlag = false;
    public delegate void BlendingStarted(Object obj);
    public static event BlendingStarted BlendingStartedEvent;
    public delegate void BlendingEnded(Object obj);
    public static event BlendingEnded BlendingEndedEvent;
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
            BlendingStartedEvent?.Invoke(clearShot);
        }
        if(!clearShot.IsBlending && InvokeOnceFlag)
        {
            InvokeOnceFlag = false;
            BlendingEndedEvent?.Invoke(clearShot);
        }
    }
}
