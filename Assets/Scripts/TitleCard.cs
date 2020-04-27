using System.Collections;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleCard : MonoBehaviour
{
    #region Fields

    private GameObject Canvas;
    private TextMeshProUGUI text;
    CanvasRenderer canvasRenderer;
    private Coroutine coroutine;
    #endregion

    private void Awake()
    {
        Canvas = transform.parent.gameObject;
        text = GetComponent<TextMeshProUGUI>();
        RoomSwitchEvents.BlendingStartedEvent += OnBlendingStart;
        canvasRenderer = GetComponent<CanvasRenderer>();
        canvasRenderer.SetAlpha(0f);
    }

    private void Start()
    { 
        coroutine = StartCoroutine(Show());
    }

    private void OnBlendingStart(Object obj)
    {
        CinemachineClearShot clearShot = (CinemachineClearShot)obj;
        text.SetText(clearShot.LiveChild.Name);
        Canvas.SetActive(true);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(Show());
    }
  
    IEnumerator Show()
    {
        for (float i = 0; i <= 1; i+=0.1f)
        {
            canvasRenderer.SetAlpha(i);   
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2.0f);
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            canvasRenderer.SetAlpha(i);
            yield return new WaitForSeconds(0.1f);
        }
        Canvas.SetActive(false);
    }
}
