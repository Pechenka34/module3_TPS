using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWeapon : MonoBehaviour
{
    [SerializeField] Fireball bulletPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        Fireball bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.LookAt(GetTargetPoint());
    }

    Vector3 GetTargetPoint()
    {
        //ray to center of the screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
}
