using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1.5f;
    public float moveRange = 1f;
    public bool useZigZag = true;

    private Vector3 startPos;

    [Header("Lifetime Settings")]
    public float maxLifetime = 5f;
    private float lifetime;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
            return;
        }

        HandleMovement();
    }

    void HandleMovement()
    {
        if (useZigZag)
        {
            float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
            transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
        }
        else
        {
            transform.position += Vector3.up * Mathf.Sin(Time.time * moveSpeed) * 0.001f;
        }
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
