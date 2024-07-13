using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem hitVFXPrefab; // Particle system prefab for hit VFX

    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate hit VFX at the collision point
        if (hitVFXPrefab != null)
        {
            Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
        }

        // Destroy bullet upon collision
        Destroy(gameObject);
    }
}
