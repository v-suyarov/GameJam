using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : AIBehavior
{
    
    [Tooltip("����� � �������, �� ������� ������ �������������� � ��������� ����")]
    [SerializeField] private float RotateDesiredDuration = 1f;
    private Quaternion prevRotate;
    private Quaternion newRotate;
    protected override void Move()
    {

        //����� ������������ (��� is_following = true ���������� ���������� ���� ������ ���, ����� progress<0, �.�. ������� �� ������ ��� ��������)
        if (progress < 0f)
        {

            target = GetRandomTarget();


            //����� � ��������� ������ ����� ������������� � ��������� ������   

            progress = 0f;
            elapsedTime = 0;
            positionFrom = transform.position;
            desiredDuration = (target - positionFrom).magnitude * GetSpeedMultiplier() * 1/Speed;
            prevRotate = transform.rotation;
            newRotate = RotateToTarget(target-transform.position);
            Debug.DrawLine(transform.position, target, Color.red, 8);
            
        }
        //�������� � �������� �������
        if (progress >= 0 && progress < 1)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / desiredDuration;
            transform.position = Vector2.Lerp(positionFrom, target, progress);
            transform.rotation = Quaternion.Slerp(prevRotate, newRotate,  elapsedTime/ RotateDesiredDuration);
            
        }
        //���� ����� �� ����� 
        if (progress >= 1)
        {
            progress = -.1f;
        }
    }
    private Quaternion RotateToTarget(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;     
        return Quaternion.AngleAxis(angle,Vector3.forward);
    }

}
