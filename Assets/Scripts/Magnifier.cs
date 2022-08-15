using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magnifier : MonoBehaviour
{
    [Tooltip("����������, �� ������� ��� ���������� ������ �� 100 ������ ��������")]
    [Range(1, 100f)] [SerializeField] private float multiplicationFactorPerPower = 2;
    [Tooltip("����������, ����� ������� �������� �������� � ������ ��� ���������� ������� �������")]
    [Range(0, 1f)] [SerializeField] private float absorptionModifier = 1f;
   

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
     
    }
    public void Increase(ObjectSettings absorbedObject)
    {
        
        transform.GetComponent<ObjectSettings>().power += Mathf.CeilToInt(absorbedObject.power*absorptionModifier);
        if(transform.GetComponent<ObjectSettings>().power> transform.GetComponent<ObjectSettings>().maxPower)
        {
            transform.GetComponent<ObjectSettings>().power = transform.GetComponent<ObjectSettings>().maxPower;
        }
        UpdateSize();
    }
}
