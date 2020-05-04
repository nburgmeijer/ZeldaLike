using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIElementsController : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private GameObject _titleCard;
    [SerializeField] private GameObject _dialog;
    private InputAction _interact;
    private TextMeshProUGUI _titleCardText;
    private TextMeshProUGUI _dialogText;
    private bool _inRange = false;
    private CanvasRenderer _titleCardRenderer;
    private GameObject _canvas;
    private bool isCoroutineRunning = false;

    void Awake()
    {
        _interact = playerControls.FindAction("Interaction");
        _interact.performed += Oninteract;
        _titleCardRenderer = _titleCard.GetComponentInChildren<CanvasRenderer>();
        _canvas = gameObject.transform.GetChild(0).gameObject;
        _titleCardText = _titleCard.GetComponentInChildren<TextMeshProUGUI>();
        _dialogText = _dialog.GetComponentInChildren<TextMeshProUGUI>();
        EventManager<SignEnterEventInfo>.RegisterListener(OnTriggerSignEnter);
        EventManager<SignExitEventInfo>.RegisterListener(OnTriggerSignExit);
        EventManager<BlendingStartEventInfo>.RegisterListener(OnRoomSwitch);
    }
    private void Start()
    {
        StartCoroutine(ShowTitleText());
    }
    private void OnRoomSwitch(BlendingStartEventInfo obj)
    {
       
    }

    private void OnEnable()
    {
        _interact.Enable();
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
            if (!isCoroutineRunning)
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
        if (!isCoroutineRunning)
        {
            _canvas.SetActive(false);
        }
        _inRange = false;
    }

    IEnumerator ShowTitleText()
    {
        isCoroutineRunning = true;
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
        isCoroutineRunning = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
