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
        if ((gameObject.CompareTag("Player")||gameObject.CompareTag("Enemy"))&&(collision.CompareTag("Player")|| collision.CompareTag("Vegetation")|| collision.CompareTag("Enemy")))
        {
            EventBus.onAbsorbed?.Invoke(gameObject.GetComponent<ObjectSettings>(),collision.gameObject.GetComponent<ObjectSettings>());
            

        }
    }
    
   
}
