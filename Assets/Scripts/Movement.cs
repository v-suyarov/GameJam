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
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       // Debug.Log(target);
    }
   
    private void Move()
    {
        if ((target - transform.position).magnitude > movementAccuracy&& isInsideBorders())
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
        EventBus.onMoved -= UpdateTarget;
    }
    private void UpdateTarget(Vector3 newTarget)
    {
        target = newTarget;
    }
    private bool isInsideBorders()
    {
        bool result = true;
       
        if (transform.position.x<LevelSettings.Instance.borders[Borders.LEFT]
            || transform.position.x > LevelSettings.Instance.borders[Borders.RIGHT]
            || transform.position.y < LevelSettings.Instance.borders[Borders.BOTTOM]
            || transform.position.y > LevelSettings.Instance.borders[Borders.TOP])
        {
            if(!LevelSettings.Instance.isInsideBorders(target))
            {
                result = false;
            }
                  
        }

        return result;
    }
}
