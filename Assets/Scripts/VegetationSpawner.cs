using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationSpawner : Spawner
{
    
    

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

   protected override void Spawn()
    {
        for (int i = 0; i < LevelSettings.Instance.GetVegetationCount(); i++)
        {
            int index = UnityEngine.Random.Range(0, prefabs.Length);
            GameObject prefab = prefabs[index];
            float scaler;
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                scaler = UnityEngine.Random.Range(1f, sizeMultiplier);
            }
            else
            {
                scaler = 1 / UnityEngine.Random.Range(1f, sizeMultiplier);
            }

            
            GameObject obj = Instantiate(prefab, GetRandomPosition(LevelSettings.Instance.GetLevelSize()), Quaternion.identity, container);
            obj.transform.localScale = new Vector3(prefab.transform.localScale.x * scaler, prefab.transform.localScale.y * scaler, obj.transform.localScale.z);

        }
    }
    
  
    
}
