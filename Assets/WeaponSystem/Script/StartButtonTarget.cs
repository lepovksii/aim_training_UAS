using UnityEngine;

public class StartButtonTarget : MonoBehaviour
{
    public void OnHit()
    {
        Debug.Log("StartButton HIT!");

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance NULL!");
            return;
        }

        GameManager.Instance.StartSession();
    }
}
