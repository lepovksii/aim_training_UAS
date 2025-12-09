using UnityEngine;

public class AIDifficultyManager : MonoBehaviour
{
    public AIAnalyzer analyzer;

    public float targetSize = 1f;
    public float targetSpeed = 1f;
    public float spawnRate = 1f;

    void Update()
    {
        if (analyzer == null) return;
        AdjustDifficulty();
    }

    private void AdjustDifficulty()
    {
        float accuracy = analyzer.accuracy;
        float reaction = analyzer.GetAverageReactionTime();

        if (accuracy > 80f && reaction < 0.8f)
        {
            targetSize = Mathf.Max(0.4f, targetSize - 0.01f);
            targetSpeed += 0.01f;
            spawnRate += 0.01f;
        }
        else if (accuracy < 50f || reaction > 1.5f)
        {
            targetSize = Mathf.Min(1.5f, targetSize + 0.01f);
            targetSpeed = Mathf.Max(0.5f, targetSpeed - 0.01f);
            spawnRate = Mathf.Max(0.5f, spawnRate - 0.01f);
        }
    }
}
