using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    [SerializeField] private int StartTime = 30;
    public static int Time { get; private set; }
    [SerializeField] private TMP_Text TimeText;

    void Awake()
    {
        if (!Instance)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Start()
    {
        
        StartCoroutine(Countdown());
    }

    private void Initialize()
    {
        Time = StartTime;
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
