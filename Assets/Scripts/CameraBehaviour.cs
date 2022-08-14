using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraBehaviour : MonoBehaviour
{
   
    
    [Tooltip("Насколько отдалиться камера по Z, за 100 едениц мощности")]
    [Range(1f, 5f)] [SerializeField] private float moveСameraBackPerPower=2;
    [Tooltip("Максимальный размер камеры неоьходим, чтобы предотвратить выход камеры за пределы уровня")]
    [SerializeField] private float maxSize = 25f;
    private float initVitVirtualCameraSize;
    private CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        Initial();
    }

  
    private void Initial()
    {
        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        initVitVirtualCameraSize = virtualCamera.m_Lens.OrthographicSize;
        
    }
    public  void moveСameraBack(int power)
    {
        virtualCamera.m_Lens.OrthographicSize = initVitVirtualCameraSize + (power / 100f) * (moveСameraBackPerPower);
        if (virtualCamera.m_Lens.OrthographicSize > maxSize)
        {
            virtualCamera.m_Lens.OrthographicSize = maxSize;
        }
    }
}
