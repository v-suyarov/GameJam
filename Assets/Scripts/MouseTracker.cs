using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 class MouseTracker : MonoBehaviour
{
    public static Action<Vector3> onMoved;
    public  Vector3 mousePosition { get; private set ; } = Vector3.zero;
   
/*    [Tooltip("Определяет минимальное растояние от последнего сохраненного положения курсора до текущего положения курсора, при котором пройизойдет обновление позиции курсора.")]
    [Range(0.05f, 5.5f)][SerializeField] public float UpdateAccuracy = 0.1f;*/
    
    

    // Update is called once per frame
    void Update()
    {
        FindMousePosition();
        
    }
    private void FindMousePosition()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
        EventBus.onMoved?.Invoke(mousePosition);
        
        
    }
}
