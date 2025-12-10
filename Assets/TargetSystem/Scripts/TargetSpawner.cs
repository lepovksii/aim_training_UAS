using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Target Settings")]
    public GameObject targetPrefab;
    public int maxTargets = 5;

    [Header("Spawn Area")]
    public Vector3 areaSize = new Vector3(5, 2, 5);

    [Header("References")]
    public AIDifficultyManager difficulty;
    public AIAnalyzer analyzer;

    private float timer;
    private float baseSpawnInterval = 1.5f;

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying()) return;

        // spawn rate mengikuti AI difficulty
        float currentInterval = baseSpawnInterval / difficulty.spawnRateMultiplier;

        timer += Time.deltaTime;
        if (timer >= currentInterval)
        {
            timer = 0f;

            if (CountTargets() < maxTargets)
                SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2),
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        GameObject obj = Instantiate(targetPrefab, transform.position + randomPos, Quaternion.identity);

        // --- APPLY DIFFICULTY ---
        obj.transform.localScale = Vector3.one * difficulty.sizeMultiplier;

        TargetBehavior tb = obj.GetComponent<TargetBehavior>();
        if (tb != null)
        {
            tb.moveSpeed *= difficulty.speedMultiplier;
        }

        analyzer?.OnTargetSpawned();
    }

    private int CountTargets()
    {
        return FindObjectsOfType<TargetBehavior>().Length;
    }
}
