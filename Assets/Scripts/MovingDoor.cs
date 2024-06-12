using UnityEngine;
using System.Collections;

public class MovingDoor : MonoBehaviour
{
    public float openHeight = 3.0f;
    public float speed = 2.0f;
    public float delay = 3.0f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
            StopAllCoroutines();

            // Play the audio clip attached to the AudioSource component
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoorAfterDelay());
        }
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        isOpening = false;
    }
}
