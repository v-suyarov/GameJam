using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : AIBehavior
{
    
    [Tooltip("Время в скундах, за которое объект поварачивается к следующей цели")]
    [SerializeField] private float RotateDesiredDuration = 1f;
    private Quaternion prevRotate;
    private Quaternion newRotate;
    protected override void Move()
    {

        //режим передвижения (при is_following = true происходит перерасчет пути каждый раз, когда progress<0, т.е. переход на клетку был закончен)
        if (progress < 0f)
        {

            target = GetRandomTarget();


            //сброс и получение данных перед передвижением к следующей клетке   

            progress = 0f;
            elapsedTime = 0;
            positionFrom = transform.position;
            desiredDuration = (target - positionFrom).magnitude * GetSpeedMultiplier() * Speed;
            prevRotate = transform.rotation;
            newRotate = RotateToTarget(target-transform.position);
            Debug.DrawLine(transform.position, target, Color.red, 8);
            
        }
        //движение к заданной позиции
        if (progress >= 0 && progress < 1)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / desiredDuration;
            transform.position = Vector2.Lerp(positionFrom, target, progress);
            transform.rotation = Quaternion.Slerp(prevRotate, newRotate,  elapsedTime/ RotateDesiredDuration);
            
        }
        //если дошли до точки 
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
