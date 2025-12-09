using UnityEngine;

public class LaserController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float maxDistance = 100f;
    public LayerMask hitMask;

    void Update()
    {
        if (lineRenderer == null || firePoint == null) return;

        Vector3 startPos = firePoint.position;
        Vector3 direction = firePoint.forward;

        // Default end position (laser panjang maksimum)
        Vector3 endPos = startPos + direction * maxDistance;

        // Cek apakah laser mengenai objek
        if (Physics.Raycast(startPos, direction, out RaycastHit hit, maxDistance, hitMask))
        {
            endPos = hit.point;  
        }

        // Set posisi laser
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
