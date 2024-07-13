using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public Transform shootSource;
    public float distance = 10f;             // Shooting distance
    public float shootDelay = 0.1f;          // Delay between shots

    private bool isShooting = false;

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        // Add listener for activated event
        grabInteractable.activated.AddListener(OnActivated);

        // Add listener for deactivated event
        grabInteractable.deactivated.AddListener(OnDeactivated);
    }

    private void OnActivated(ActivateEventArgs args)
    {
        if (args.interactorObject is IXRActivateInteractor activateInteractor)
        {
            StartShooting(activateInteractor); // Call StartShooting with the interactorObject
        }
    }

    private void OnDeactivated(DeactivateEventArgs args)
    {
        if (args.interactorObject is IXRActivateInteractor activateInteractor)
        {
            StopShooting(activateInteractor); // Call StopShooting with the interactorObject
        }
    }

    private void StartShooting(IXRActivateInteractor interactor)
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootingRoutine());
        }
    }

    private void StopShooting(IXRActivateInteractor interactor)
    {
        isShooting = false;
        // Add any necessary cleanup for shooting here
    }

    private IEnumerator ShootingRoutine()
    {
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(shootDelay);
        }
    }

    private void Shoot()
    {
        // Get shooting particle from object pool
        GameObject shootingParticle = ObjectPoolManager.Instance.GetPooledObject();
        if (shootingParticle != null)
        {
            shootingParticle.transform.position = shootSource.position;
            shootingParticle.transform.rotation = shootSource.rotation;

            // Activate and play shooting particle
            shootingParticle.SetActive(true);
            shootingParticle.GetComponent<ParticleSystem>().Play();

            // Deactivate after particle duration
            StartCoroutine(DeactivateAfterTime(shootingParticle));
        }

        // Perform raycast to detect hits
        RaycastCheck();
    }

    private IEnumerator DeactivateAfterTime(GameObject obj)
    {
        yield return new WaitForSeconds(distance / 10); // Adjust as per particle speed and distance
        obj.SetActive(false);
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance))
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
