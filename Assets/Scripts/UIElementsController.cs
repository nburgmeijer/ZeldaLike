using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIElementsController : MonoBehaviour
{ 
    [SerializeField] private GameObject _titleCard;
    [SerializeField] private GameObject _dialog;
    [SerializeField] private GameObject _canvas;
    private TextMeshProUGUI _titleCardText;
    private TextMeshProUGUI _dialogText;
    private bool _inRange = false;
    private CanvasRenderer _titleCardRenderer;
    private Coroutine _coroutine;
    private PlayerControls _playerControls;
    private InputAction _interact;

    void Awake()
    {
        //Cursor.visible = false;
        _playerControls = new PlayerControls();
        _interact = _playerControls.PlayerControlsActionMap.Interaction;
        _interact.performed += Oninteract;
        _titleCardRenderer = _titleCard.GetComponentInChildren<CanvasRenderer>();
        _titleCardText = _titleCard.GetComponentInChildren<TextMeshProUGUI>();
        _dialogText = _dialog.GetComponentInChildren<TextMeshProUGUI>();
        EventManager<SignEnterEventInfo>.RegisterListener(OnTriggerSignEnter);
        EventManager<SignExitEventInfo>.RegisterListener(OnTriggerSignExit);
        EventManager<RoomSwitchEventInfo>.RegisterListener(OnRoomSwitch);
    }

    private void OnRoomSwitch(RoomSwitchEventInfo eventInfo)
    {
        _titleCardText.SetText(eventInfo.virtualCameraName);
        _canvas.SetActive(true);
        gameObject.SetActive(true);
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ShowTitleText());
    }

    private void OnEnable()
    {
        _interact.Enable();
        _coroutine = StartCoroutine(ShowTitleText());
    }

    private void OnDisable()
    {
        _interact.Disable();
    }

    private void Oninteract(InputAction.CallbackContext context)
    {
        if (_inRange && !_dialog.activeSelf)
        {
            _dialog.SetActive(true);
            _canvas.SetActive(true);
        }
        else
        {
            _dialog.SetActive(false);
            if (_coroutine == null)
            {
                _canvas.SetActive(false);
            }
        }  
    }

    private void OnTriggerSignEnter(SignEnterEventInfo eventInfo)
    {
        _dialogText.SetText(eventInfo.signInfo);        
        _inRange = true;
    }
    private void OnTriggerSignExit(SignExitEventInfo eventInfo)
    {
        _dialog.SetActive(false);
        if (_coroutine == null)
        {
            _canvas.SetActive(false);
        }
        _inRange = false;
    }

    IEnumerator ShowTitleText()
    {
        _canvas.SetActive(true);
        _titleCard.SetActive(true);

        for (float i = 0; i <= 1; i += 0.1f)
        {
            _titleCardRenderer.SetAlpha(i);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2.0f);
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            _titleCardRenderer.SetAlpha(i);
            yield return new WaitForSeconds(0.1f);
        }

        _titleCard.SetActive(false);
        _canvas.SetActive(false);   
    }
}
