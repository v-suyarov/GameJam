using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
   
    private void OnEnable()
    {
        EventBus.onAbsorbed +=AbsorptionProcessing;
    }
    private void OnDisable()
    {
        EventBus.onAbsorbed -= AbsorptionProcessing;
    }
    
    private void AbsorptionProcessing(ObjectSettings objectSettings1, ObjectSettings objectSettings2)
    {
        if(objectSettings1.power>=objectSettings2.power)
        {
            GameObject.Destroy(objectSettings2.gameObject);
        }
        else
        {
            GameObject.Destroy(objectSettings1.gameObject);
            return;
        }

        if(objectSettings1.CompareTag("Player"))
        {
            Timer.Instance.AddTimer(objectSettings2.timeForEating);
        }
    }

}
