using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraBehaviour : MonoBehaviour
{
   
    
    [Tooltip("��������� ���������� ������ �� Z, �� 100 ������ ��������")]
    [Range(1f, 5f)] [SerializeField] private float move�ameraBackPerPower=2;
    [Tooltip("������������ ������ ������ ���������, ����� ������������� ����� ������ �� ������� ������")]
    [SerializeField] private float maxSize = 25f;
    private float initVitVirtualCameraSize;
    private CinemachineVirtualCamera virtualCamera;
    [Tooltip("�� ����� ����� � �������� ��������� ������ ������")]
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
       
    }

    private void UpdateSize()
    {
        //����� ������������ (��� is_following = true ���������� ���������� ���� ������ ���, ����� progress<0, �.�. ������� �� ������ ��� ��������)
        if (progress < 0f&&cameraSize.Count>0)
        {

            nextSize = cameraSize.Dequeue();


            //����� � ��������� ������ ����� ������������� � ��������� ������   

            progress = 0f;
            elapsedTime = 0;
            sizeFrom = virtualCamera.m_Lens.OrthographicSize;
            
        }
        //�������� � �������� �������
        if (progress >= 0 && progress < 1)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / desiredDuration;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(sizeFrom, nextSize, progress);
            

        }
        //���� ����� �� ����� 
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
        float nextSize = initVitVirtualCameraSize + (power / 100f) * (move�ameraBackPerPower);
        if (nextSize > maxSize)
        {
            nextSize = maxSize;
        }
        cameraSize.Enqueue(nextSize);
    }
}
