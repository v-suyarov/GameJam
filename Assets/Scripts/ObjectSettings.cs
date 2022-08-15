using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSettings : MonoBehaviour
{
    [Tooltip("Сколько очков добавится при поглощении этого объекта")]
    public int timeForEating = 1;
    [Tooltip("Мощьность определяет, какой из объектов будет поглащен, большая мощность поглащает меньшую")]
    public int power  = 0;

}
