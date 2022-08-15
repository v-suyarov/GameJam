using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [Tooltip("Множитель мощности, чем больше число, тем более разнообразными будут размеры и мощность объектов")]
    [Range(1f, 50f)][SerializeField] protected float powerMultiplier = 1.5f;
    [SerializeField] protected GameObject[] prefabs = new GameObject[1];
    protected private Transform container;
    
    private void Awake()
    {
        container = transform;
       
    }
    
    protected Vector3 GetRandomPosition(int maxDistance)
    {
        Vector3 pos = Vector3.zero;
        pos.x = UnityEngine.Random.Range(0, LevelSettings.Instance.GetLevelSize()) - 50;
        pos.y = UnityEngine.Random.Range(0, LevelSettings.Instance.GetLevelSize()) - 50;
        return pos;
    }
    protected abstract void Spawn();
   

}
