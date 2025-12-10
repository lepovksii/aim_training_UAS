using System.Collections.Generic;
using UnityEngine;

public class AIAnalyzer : MonoBehaviour
{
    public int totalHits = 0;
    public int totalMiss = 0;
    public float accuracy = 0f;

    private List<float> reactionTimes = new List<float>();
    private float lastTargetSpawnTime;

    public void OnTargetSpawned()
    {
        lastTargetSpawnTime = Time.time;
    }

    public void OnTargetHit()
    {
        totalHits++;
        float reaction = Time.time - lastTargetSpawnTime;

        if (reaction > 0f)
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
        accuracy = totalShots > 0 ? (float)totalHits / totalShots * 100f : 0f;
    }

    public float GetAverageReactionTime()
    {
        if (reactionTimes.Count == 0) return 0f;

        float total = 0f;
        for (int i = 0; i < reactionTimes.Count; i++)
            total += reactionTimes[i];

        return total / reactionTimes.Count;
    }

    public void ResetStats()
    {
        totalHits = 0;
        totalMiss = 0;
        accuracy = 0f;
        reactionTimes.Clear();
    }
}
