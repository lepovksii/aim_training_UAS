using UnityEngine;

public class PlayerInputTest : MonoBehaviour
{
    public GunController gun;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gun.Shoot();
        }
    }
}
