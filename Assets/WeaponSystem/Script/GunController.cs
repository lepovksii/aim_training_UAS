using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public AudioSource audioSource;
    public AudioClip fireSound;
    public AIAnalyzer analyzer;

    public void Shoot()
    {
        GameManager.Instance?.RegisterShot();

        if (muzzleFlash != null) muzzleFlash.Play();
        if (audioSource != null && fireSound != null)
            audioSource.PlayOneShot(fireSound);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            // 1. START MENU BUTTON
            StartButtonTarget startButton = hit.transform.GetComponent<StartButtonTarget>();
            if (startButton != null)
            {
                startButton.OnHit();
                return;
            }

            // 2. TARGET BIASA
            if (hit.transform.CompareTag("Target"))
            {
                GameManager.Instance?.RegisterHit();
                analyzer?.OnTargetHit();

                TargetBehavior tb = hit.transform.GetComponent<TargetBehavior>();
                if (tb != null) tb.OnHit();
                else Destroy(hit.transform.gameObject);
            }
            else
            {
                analyzer?.OnMiss();
            }
        }
        else
        {
            analyzer?.OnMiss();
        }
    }
}
