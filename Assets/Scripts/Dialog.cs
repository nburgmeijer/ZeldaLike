using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialog : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    private bool inRange = false;
    private GameObject canvas;
    private string text;
    private TextMeshProUGUI tmp;
    private InputAction interaction;
   
    private void Awake()
    {
        interaction = playerControls.FindAction("Interaction");
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        canvas = transform.parent.gameObject;
        EventManager<SignEnterEventInfo>.RegisterListener(OnTriggerSignEnter);
        EventManager<SignExitEventInfo>.RegisterListener(OnTriggerSignExit);
        interaction.performed += OnInteract;
        interaction.Enable();
        gameObject.SetActive(false);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (inRange && !gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            canvas.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            canvas.SetActive(false);
        }
    }

    private void OnTriggerSignEnter(SignEnterEventInfo eventInfo)
    {
        text = eventInfo.signInfo;
        tmp.SetText(text);
        inRange = true;
    }

    private void OnTriggerSignExit(SignExitEventInfo eventInfo)
    {
        gameObject.SetActive(false);
        canvas.SetActive(false);
        inRange = false;
    }
}
