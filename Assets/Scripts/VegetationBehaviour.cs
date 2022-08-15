using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationBehaviour : AIBehavior
{
    private void OnDestroy()
    {
        VegetationSpawner.countObject--;
    }
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


        }
        //движение к заданной позиции
        if (progress >= 0 && progress < 1)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / desiredDuration;
            transform.position = Vector2.Lerp(positionFrom, target, progress);
        }
        //если дошли до точки 
        if (progress >= 1)
        {
            progress = -.1f;
        }
    }
   
 
}
