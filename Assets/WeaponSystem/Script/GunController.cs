using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;
    public LayerMask targetLayer;
    public ParticleSystem muzzleFlash;
    public AudioSource audioSource;
    public AudioClip fireSound;

    public void Shoot()
    {
        if (muzzleFlash != null) muzzleFlash.Play();
        if (audioSource != null && fireSound != null) audioSource.PlayOneShot(fireSound);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range, targetLayer))
        {
            Debug.Log("Kena: " + hit.transform.name);
            if (hit.transform.CompareTag("Target"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}