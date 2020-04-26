using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    #region Fields

    [SerializeField] private bool orderOnce;
    private readonly int orderBase = 5000;
    private SpriteRenderer spriteRenderer;
    private float timer;
    private readonly float timeMax = 0.1f;
    #endregion

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {        
            timer = timeMax;
            spriteRenderer.sortingOrder = (int)(orderBase - (transform.position.y) * 10);
            if (orderOnce)
            {
                Destroy(this);
            }
        }
        
    }
}
