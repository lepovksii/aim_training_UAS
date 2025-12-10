using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveRange = 1f;
    public bool useZigZag = true;

    private float lifetime;
    public float maxLifetime = 5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
            Destroy(gameObject);

        MovePattern();
    }

    void MovePattern()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
