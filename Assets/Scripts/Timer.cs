using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private int StartTime = 30;
    public static int Time { get; private set; }
    [SerializeField] private TMP_Text TimeText;

    private void Start()
    {
        Time = StartTime;
        StartCoroutine(Countdown());
    }

   
    private IEnumerator Countdown()
    {
        TimeText.text = Time.ToString();
        while (Time > 0)
        {
            yield return new WaitForSeconds(1);
            Time -= 1;
            TimeText.text = Time.ToString();
        }
        //сигнал окончания игры

    }

    public void  AddTimer(int addTime)
    {
        Time += addTime;
        TimeText.text = Time.ToString();
    }
}
