using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour { 
    public static int score { get; private set;}
    float lastEnemyKillTime;
    int streakCount;
    float streakExpiryTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnDeathStatic += OnEnemyKilled;
        FindObjectOfType<Player>().OnDeath += OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnemyKilled()
    {
        if (Time.time < lastEnemyKillTime + streakExpiryTime)
        {
            ++streakCount;
        }
        else
        {
            streakCount = 0;
        }
        lastEnemyKillTime = Time.time;

        score += 5 + (int)Mathf.Pow(2,streakCount);
    }

    void OnPlayerDeath()
    {
        score = 0;
        Enemy.OnDeathStatic -= OnEnemyKilled;
    }
}
