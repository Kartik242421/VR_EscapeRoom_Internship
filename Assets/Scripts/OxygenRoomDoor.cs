using UnityEngine;
using System.Collections;

public class OxygenRoomDoor : MonoBehaviour
{
    public Vector3 localTargetPosition; // Target position to move the object to
    public float speed = 2.0f; // Speed at which the object moves

    private Vector3 initialPosition; // Initial position of the object
    private bool isMovingToTarget = false; // Flag to check if the object is moving towards the target
    private AudioSource audioSource; // Audio source component

    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
    }

    void Update()
    {
        if (isMovingToTarget)
        {
            // Move towards the target position
            transform.localPosition = Vector3.Lerp(transform.localPosition, localTargetPosition, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the trigger was entered by the player
        {
            isMovingToTarget = true; // Set the flag to move towards the target position
            if (audioSource != null)
            {
                audioSource.Play(); // Play the audio source if available
            }
        }
    }
}
