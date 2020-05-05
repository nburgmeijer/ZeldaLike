using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _canOpen = false;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (_canOpen)
            {
                _spriteRenderer.color = new Color(1, 1, 1, 0);
                _boxCollider.isTrigger = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _spriteRenderer.color = new Color(1, 1, 1, 1);
            _boxCollider.isTrigger = false;
            gameObject.SetActive(true);
        }
    }
}
