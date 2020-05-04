using System.Collections;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleCard : MonoBehaviour
{
    #region Fields
    private GameObject canvas;
    private TextMeshProUGUI text;
    CanvasRenderer canvasRenderer;
    private Coroutine coroutine;
    #endregion

    private void Awake()
    {
        canvas = transform.parent.gameObject;
        text = GetComponent<TextMeshProUGUI>();
        canvasRenderer = GetComponent<CanvasRenderer>();
        canvasRenderer.SetAlpha(0f);
        EventManager<BlendingStartEventInfo>.RegisterListener(OnBlendingStart);
    }

    private void Start()
    {
            coroutine = StartCoroutine(Show());
    }

    private void OnBlendingStart(BlendingStartEventInfo eventInfo)
    {
        CinemachineClearShot clearShot = eventInfo.clearShot;
        text.SetText(clearShot.LiveChild.Name);
        canvas.SetActive(true);
        gameObject.SetActive(true);
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
        
        gameObject.SetActive(false);
        canvas.SetActive(false);
    }
}
