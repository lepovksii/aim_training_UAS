using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;
    public LayerMask targetLayer;

    public ParticleSystem muzzleFlash;
    public AudioSource audioSource;
    public AudioClip fireSound;

    void Update()
    {
        // VR/PC input — sesuaikan sesuai XR Device Simulator atau VR controller nanti
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            GameManager.Instance.RegisterShot();
        }
    }

    public void Shoot()
    {
        if (muzzleFlash != null) muzzleFlash.Play();
        if (audioSource != null && fireSound != null) audioSource.PlayOneShot(fireSound);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range, targetLayer))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Jika target punya script StartButtonTarget (button start)
            StartButtonTarget startBtn = hit.transform.GetComponent<StartButtonTarget>();
            if (startBtn != null)
            {
                startBtn.OnHit();
                return;
            }

            // Jika target biasa
            TargetBehavior target = hit.transform.GetComponent<TargetBehavior>();
            if (target != null)
            {
                target.OnHit();
                GameManager.Instance.RegisterHit();
            }
        }
    }
}
