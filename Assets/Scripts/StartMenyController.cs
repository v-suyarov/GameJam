using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenyController : MonoBehaviour
{
    public GameObject leaderboardView;
    public Leaderboard leaderboard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableLeaderboard(bool state)
    {
        if(state==true)
        {
            leaderboardView.SetActive(true);
            StartCoroutine(leaderboard.FetchTopHighscoresRoutine());
        }
        else
        {
            leaderboardView.SetActive(false);
        }
    }
}
