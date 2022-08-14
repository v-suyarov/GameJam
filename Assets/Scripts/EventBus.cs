using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class EventBus 
{
    public static Action<Vector3> onMoved;
    public static Action<ObjectSettings, ObjectSettings> onAbsorbed;
    public static Action onUpdateSize;
}
