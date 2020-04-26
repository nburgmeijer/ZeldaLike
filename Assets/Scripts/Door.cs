using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool canOpen = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (canOpen)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
                boxCollider.isTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            boxCollider.isTrigger = false;
        }
    }
}
