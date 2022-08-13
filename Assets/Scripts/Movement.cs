using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 target = Vector3.zero;
    private float movementAccuracy = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.onMoved += UpdateTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       // Debug.Log(target);
    }
   
    private void Move()
    {
        if ((target - transform.position).magnitude > movementAccuracy)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }    

    private void OnEnable()
    {
       EventBus.onMoved += UpdateTarget;
    }
    private void OnDisable()
    {
        MouseTracker.onMoved -= UpdateTarget;
    }
    private void UpdateTarget(Vector3 newTarget)
    {
        target = newTarget;
    }
}
