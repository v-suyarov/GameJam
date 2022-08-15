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
    [Tooltip("За какое время в секундах обновится размер камеры")]
    [SerializeField]private float desiredDuration = 1f;
    private float elapsedTime = 0f;
    private float nextSize;
    private float progress = -1f;
    private float sizeFrom;
    private Queue<float> cameraSize = new Queue<float>();
    void Start()
    {
        Initial();
    }
    private void Update()
    {
        UpdateSize();
        Debug.Log(VegetationSpawner.countObject);
    }

    private void UpdateSize()
    {
        //режим передвижения (при is_following = true происходит перерасчет пути каждый раз, когда progress<0, т.е. переход на клетку был закончен)
        if (progress < 0f&&cameraSize.Count>0)
        {

            nextSize = cameraSize.Dequeue();


            //сброс и получение данных перед передвижением к следующей клетке   

            progress = 0f;
            elapsedTime = 0;
            sizeFrom = virtualCamera.m_Lens.OrthographicSize;
            
        }
        //движение к заданной позиции
        if (progress >= 0 && progress < 1)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / desiredDuration;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(sizeFrom, nextSize, progress);
            

        }
        //если дошли до точки 
        if (progress >= 1)
        {
            progress = -.1f;
        }
    }
    private void Initial()
    {
        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        initVitVirtualCameraSize = virtualCamera.m_Lens.OrthographicSize;
        
    }
    public  void AddCameraSize(int power)
    {
        float nextSize = initVitVirtualCameraSize + (power / 100f) * (moveСameraBackPerPower);
        if (nextSize > maxSize)
        {
            nextSize = maxSize;
        }
        cameraSize.Enqueue(nextSize);
    }
}
