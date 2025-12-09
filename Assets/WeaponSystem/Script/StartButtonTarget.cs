using UnityEngine;

public class StartButtonTarget : MonoBehaviour
{
    public void OnHit()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartSession();
        }
    }
}
