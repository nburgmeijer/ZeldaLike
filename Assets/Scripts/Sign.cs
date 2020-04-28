using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sign : MonoBehaviour
{
    public UnityEvent triggerEvent;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent.Invoke();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 