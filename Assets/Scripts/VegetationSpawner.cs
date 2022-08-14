using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationSpawner : Spawner
{
   protected override void Spawn()
    {
        for (int i = 0; i < LevelSettings.Instance.GetVegetationCount(); i++)
        {
            int index = UnityEngine.Random.Range(0, prefabs.Length);
            GameObject prefab = prefabs[index];
            float scaler;
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                scaler = UnityEngine.Random.Range(1f, powerMultiplier);
            }
            else
            {
                scaler = 1 / UnityEngine.Random.Range(1f, powerMultiplier);
            }


            GameObject obj = Instantiate(prefab, GetRandomPosition(LevelSettings.Instance.GetLevelSize()), Quaternion.identity, container);
            obj.GetComponent<ObjectSettings>().power = (int)(prefab.GetComponent<ObjectSettings>().power * scaler);
           

        }
        
    }
    
  
    
}
