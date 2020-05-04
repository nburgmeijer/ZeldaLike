using System;
using UnityEngine;
using Cinemachine;


public class VirtualCamSwitch : MonoBehaviour
{
    private bool _isBlending;
    private CinemachineBrain _cinemachineBrain;
    private CinemachineClearShot _cinemachineClearShot;

    private void Awake()
    {
        _cinemachineBrain = GetComponent<CinemachineBrain>();
        _cinemachineBrain.m_CameraActivatedEvent.AddListener(OnVirtualCameraActivated);
    }

    private void OnVirtualCameraActivated(ICinemachineCamera toCamera, ICinemachineCamera fromCamera)
    {
        if (toCamera.GetType() != typeof(CinemachineClearShot))
        {
            EventManager<RoomSwitchEventInfo>.InvokeEvent(new RoomSwitchEventInfo() { virtualCameraName = toCamera.Name });
            CinemachineVirtualCamera a = new CinemachineVirtualCamera();
            
            _isBlending = true;
        }
        else
        {
            _cinemachineClearShot = (CinemachineClearShot)toCamera;
        }
    }
    private void Update()
    {
        if(_isBlending && !_cinemachineClearShot.IsBlending)
        {
           
                EventManager<BlendingEndEventInfo>.InvokeEvent(new BlendingEndEventInfo());
                _isBlending = false;
            
        }
    }
}
