using UnityEngine;

public class AIGrading : MonoBehaviour
{
    public AIAnalyzer analyzer;

    public string GetFinalGrade()
    {
        if (analyzer == null) return "N/A";

        float accuracy = analyzer.accuracy;
        float reaction = analyzer.GetAverageReactionTime();
        int hits = analyzer.totalHits;

        if (accuracy >= 90 && reaction < 0.7f && hits > 25)
            return "S";
        else if (accuracy >= 80 && reaction < 1.0f)
            return "A";
        else if (accuracy >= 70)
            return "B";
        else if (accuracy >= 50)
            return "C";
        else
            return "D";
    }
}
