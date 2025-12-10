using UnityEngine;

public class AIGrading : MonoBehaviour
{
    public AIAnalyzer analyzer;

    public string GetFinalGrade()
    {
        if (analyzer == null) return "-";

        float accuracy = analyzer.accuracy;
        float reaction = analyzer.GetAverageReactionTime();
        int hits = analyzer.totalHits;

        if (hits >= 20 && accuracy >= 90 && reaction <= 0.8f) return "S";
        if (accuracy >= 80 && reaction <= 1.2f) return "A";
        if (accuracy >= 70) return "B";
        if (accuracy >= 50) return "C";

        return "D";
    }
}
