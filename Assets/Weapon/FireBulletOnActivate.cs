using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitVFXPrefab; // Particle system prefab for hit VFX

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    void FireBullet(ActivateEventArgs args)
    {
        // Perform raycast to determine where to spawn bullet and detect collisions
        RaycastHit hit;
        Vector3 targetPosition = spawnPoint.position + spawnPoint.forward * 100f; // Assuming max distance

        // Raycast to detect collisions
        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit))
        {
            targetPosition = hit.point; // Update target position to hit point

            // Instantiate hit VFX at the hit point
            if (hitVFXPrefab != null)
            {
                Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);
            }
        }

        // Instantiate muzzle flash at spawn point
        if (muzzleFlash != null)
        {
            muzzleFlash.transform.position = spawnPoint.position;
            muzzleFlash.Play();
        }

        // Instantiate bullet and set its velocity towards the target position
        GameObject spawnedBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            Vector3 fireDirection = (targetPosition - spawnPoint.position).normalized;
            bulletRigidbody.velocity = fireDirection * fireSpeed;
        }
    }
}
