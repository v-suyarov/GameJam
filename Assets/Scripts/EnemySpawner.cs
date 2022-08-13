using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int EnemysCount = 90;
    [SerializeField] private GameObject[] prefabsEnemys = new GameObject[5];
    private Transform containerEnemys;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawn()
    {
        containerEnemys = GameObject.Find("Enemys").GetComponent<Transform>();
        for (int i = 0; i < EnemysCount; i++)
        {
            int enemyIndex = UnityEngine.Random.Range(0, prefabsEnemys.Length);

            Instantiate(prefabsEnemys[enemyIndex], GetRandomPosition(100), Quaternion.identity, containerEnemys);
        }
    }
    private Vector3 GetRandomPosition(int maxDistance)
    {
        Vector3 pos = Vector3.zero;
        pos.x = UnityEngine.Random.Range(0,100)-50;
        pos.y = UnityEngine.Random.Range(0, 100)-50;
        return pos;
    }
}
