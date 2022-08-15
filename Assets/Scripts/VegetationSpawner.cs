using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationSpawner : Spawner
{
    [Tooltip("Время в секундах до создания следующего объекта")]
    [Range(0.001f, 1f)] [SerializeField] protected float timerateSpawn = 0.1f;
    static public  int countObject = 0;
    private void Start()
    {
        Spawn();
        EventBus.onUpdateSize?.Invoke();
        StartCoroutine(Spawner(timerateSpawn));
    }
    protected override void Spawn()
    {
        for (int i = 0; i < LevelSettings.Instance.GetVegetationCount(); i++)
        {
            int index = UnityEngine.Random.Range(0, prefabs.Length);
            GameObject prefab = prefabs[index];
            float scaler = UnityEngine.Random.Range(1f, powerMultiplier);
          


            GameObject obj = Instantiate(prefab, GetRandomPosition(LevelSettings.Instance.GetLevelSize()), Quaternion.identity, container);
            
            obj.GetComponent<ObjectSettings>().power = Mathf.CeilToInt((prefab.GetComponent<ObjectSettings>().power * scaler));
            countObject++;

        }
        Debug.Log(countObject);
        
    }
    IEnumerator Spawner(float timerateSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(timerateSpawn);
            if (countObject < LevelSettings.Instance.GetVegetationCount())
            {
                int index = UnityEngine.Random.Range(0, prefabs.Length);
                GameObject prefab = prefabs[index];
                float scaler = UnityEngine.Random.Range(1f, powerMultiplier);



                GameObject obj = Instantiate(prefab, GetRandomPosition(LevelSettings.Instance.GetLevelSize()), Quaternion.identity, container);

                obj.GetComponent<ObjectSettings>().power = Mathf.CeilToInt((prefab.GetComponent<ObjectSettings>().power * scaler));
                countObject++;
            }
        }
    }
  
    
}
