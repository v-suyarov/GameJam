using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehavior : MonoBehaviour
{
    [Tooltip("ћаксимальное расто€ние, на котором будет создана точка, к которой будет двигатьс€ объект")]
    [Range(0f, 100f)] [SerializeField] protected float maxDistance = 1f;

    [SerializeField] protected float Speed = 1f;
    [Tooltip("ћножитель скорости, множитель будет иметь значение из отрезка [1/value:value]")]
    [SerializeField] protected float SpeedMultiplier = 2f;
    protected float desiredDuration = 1f;
    protected float elapsedTime = 0f;
    protected Vector3 target;
    protected float progress = -1f;
    protected Vector3 positionFrom;

    private void Start()
    {
        target = transform.position;
    }
    private void Update()
    {
        Move();
    }
    protected abstract void Move();

    protected float GetSpeedMultiplier()
    {
        float multiplier;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            multiplier = UnityEngine.Random.Range(1f, SpeedMultiplier);
            
        }
        else
        {
            multiplier = 1 / UnityEngine.Random.Range(1f, SpeedMultiplier);
            
        }
        return multiplier;
    }
    protected Vector3 GetRandomTarget()
    {
        Vector3 newTarget = target;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            newTarget.x += UnityEngine.Random.Range(0, maxDistance);
        }
        else
        {
            newTarget.x += -UnityEngine.Random.Range(0, maxDistance);
        }
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            newTarget.y += UnityEngine.Random.Range(0, maxDistance);
        }
        else
        {
            newTarget.y += -UnityEngine.Random.Range(0, maxDistance);
        }



        if (!LevelSettings.Instance.isInsideBorders(newTarget))
        {
            Vector3 tempTarget = target;

            tempTarget.x = UnityEngine.Random.Range(LevelSettings.Instance.borders[Borders.LEFT], LevelSettings.Instance.borders[Borders.RIGHT]);
            tempTarget.y = UnityEngine.Random.Range(LevelSettings.Instance.borders[Borders.BOTTOM], LevelSettings.Instance.borders[Borders.TOP]);

            newTarget = tempTarget;
        }
        return newTarget;
    }
}
