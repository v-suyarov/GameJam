using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSettings : MonoBehaviour
{
    [Tooltip("������� ����� ��������� ��� ���������� ����� �������")]
    public int timeForEating = 1;
    [Tooltip("��������� ����������, ����� �� �������� ����� ��������, ������� �������� ��������� �������")]
    public int power  = 0;
    public int maxPower = 3000;
}
