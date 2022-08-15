using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magnifier : MonoBehaviour
{
    [Tooltip("Определяет, во сколько раз увеличится объект за 100 единиц мощности")]
    [Range(1, 100f)] [SerializeField] private float multiplicationFactorPerPower = 2;
    [Tooltip("Определяет, какой процент мощности перейдет к объкту при поглощении другого объекта")]
    [Range(0, 1f)] [SerializeField] private float absorptionModifier = 1f;
    [Tooltip("Максимальный размер до которого можно вырасти")]
    [SerializeField] private float maxSize = 15f;

    private Vector3 initScale;
    private void Awake()
    {
        initScale = transform.localScale;
        
    }
    private void OnEnable()
    {
        EventBus.onUpdateSize += UpdateSize;
    }
    private void OnDisable()
    {
        EventBus.onUpdateSize -= UpdateSize;
    }

    public void UpdateSize()
    {
       
       int power = transform.GetComponent<ObjectSettings>().power;
       
        
       transform.localScale = initScale +  new Vector3((power / 100f)*(multiplicationFactorPerPower-1), (power / 100f) * (multiplicationFactorPerPower - 1), 0); 
       if (transform.localScale.x>maxSize)
        {
            transform.localScale=new Vector3(maxSize, maxSize, 0);
        }
    }
    public void Increase(ObjectSettings absorbedObject)
    {
        if (transform.CompareTag("Player"))
        {
            Debug.Log(123);
        }
        transform.GetComponent<ObjectSettings>().power += Mathf.CeilToInt(absorbedObject.power*absorptionModifier);
        UpdateSize();
    }
}
