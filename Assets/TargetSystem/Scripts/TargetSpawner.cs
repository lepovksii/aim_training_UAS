using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnInterval = 1.5f;
    public int maxTargets = 5;

    public Vector3 areaSize = new Vector3(5, 2, 5);

    private float timer;

    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            if (CountTargets() < maxTargets)
            {
                SpawnTarget();
            }
        }
    }

    void SpawnTarget()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2),
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        Vector3 spawnPos = transform.position + randomPos;
        Instantiate(targetPrefab, spawnPos, Quaternion.identity);
    }

    int CountTargets()
    {
        return FindObjectsOfType<TargetBehavior>().Length;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }
}
