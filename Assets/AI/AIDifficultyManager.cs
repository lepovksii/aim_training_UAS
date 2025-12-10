using UnityEngine;

public class AIDifficultyManager : MonoBehaviour
{
    public AIAnalyzer analyzer;

    [Header("Difficulty Output")]
    public float sizeMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float spawnRateMultiplier = 1f;

    private void Update()
    {
        if (analyzer == null) return;
        AdjustDifficulty();
    }

    private void AdjustDifficulty()
    {
        float accuracy = analyzer.accuracy;
        float reaction = analyzer.GetAverageReactionTime();

        // PLAYER PRO = buat game lebih susah
        if (accuracy >= 80f && reaction < 1.0f)
        {
            sizeMultiplier = Mathf.Max(0.4f, sizeMultiplier - 0.003f);
            speedMultiplier += 0.003f;
            spawnRateMultiplier = Mathf.Min(2.0f, spawnRateMultiplier + 0.003f);
        }
        // PLAYER KESULITAN = buat lebih mudah
        else if (accuracy < 50f || reaction > 1.5f)
        {
            sizeMultiplier = Mathf.Min(1.4f, sizeMultiplier + 0.003f);
            speedMultiplier = Mathf.Max(0.8f, speedMultiplier - 0.003f);
            spawnRateMultiplier = Mathf.Max(0.6f, spawnRateMultiplier - 0.003f);
        }
    }
}
