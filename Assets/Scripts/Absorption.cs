using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{
    
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player") && collision.CompareTag("Vegetation"))
        {
            EventBus.onAbsorbed?.Invoke(collision.tag);
            Destroy(collision.gameObject);

        }
    }
    
   
}
