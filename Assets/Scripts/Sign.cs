using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sortingOrder = 2;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sortingOrder = 0;
    }
}
