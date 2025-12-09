using UnityEngine;
using System.Collections.Generic;

public class AIAnalyzer : MonoBehaviour
{
    public int totalHits = 0;
    public int totalMiss = 0;
    public float accuracy = 0f;

    private List<float> reactionTimes = new List<float>();
    private float targetSpawnTime;

    public void OnTargetSpawned()
    {
        targetSpawnTime = Time.time;
    }

    public void OnTargetHit()
    {
        totalHits++;

        float reaction = Time.time - targetSpawnTime;
        reactionTimes.Add(reaction);

        UpdateAccuracy();
    }

    public void OnMiss()
    {
        totalMiss++;
        UpdateAccuracy();
    }

    private void UpdateAccuracy()
    {
        int totalShots = totalHits + totalMiss;
        if (totalShots > 0)
            accuracy = (float)totalHits / totalShots * 100f;
    }

    public float GetAverageReactionTime()
    {
        if (reactionTimes.Count == 0) return 0f;

        float total = 0f;
        foreach (float t in reactionTimes)
            total += t;

        return total / reactionTimes.Count;
    }
}
