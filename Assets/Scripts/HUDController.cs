using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text accuracyText;
    public TMP_Text timerText;

    public void UpdateHUD(int hits, int shots, float timeRemaining)
    {
        int score = hits;
        float accuracy = 0f;

        if (shots > 0)
        {
            accuracy = (float)hits / shots * 100f;
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (accuracyText != null)
        {
            accuracyText.text = "Accuracy: " + accuracy.ToString("0") + "%";
        }

        if (timerText != null)
        {
            int t = Mathf.CeilToInt(timeRemaining);
            timerText.text = "Time: " + t + "s";
        }
    }
}
