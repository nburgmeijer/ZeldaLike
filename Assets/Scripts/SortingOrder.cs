using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    [SerializeField] private bool orderOnce;
    [SerializeField] private float offset;
    private int orderBase = 5000;
    private Renderer renderer;
    private float timer;
    private float timeMax = 0.1f;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            
            timer = timeMax;
            renderer.sortingOrder = (int)(orderBase - (transform.position.y)*10 - offset);
            if (orderOnce)
            {
                Destroy(this);
            }
        }
        
    }

}
