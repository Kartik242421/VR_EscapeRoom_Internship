using UnityEngine;

public class OxygenRoomDoor : MonoBehaviour
{
    public Vector3 localTargetPosition; // Target position to move the object to
    public float speed = 2.0f; // Speed at which the object moves

    private Vector3 initialPosition; // Initial position of the object
    public bool isMovingToTarget = false; // Flag to check if the object is moving towards the target
    //private AudioSource audioSource; // Audio source component

    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        //audioSource = GetComponent<AudioSource>(); // Get the audio source component
    }

    void Update()
    {
        if (isMovingToTarget)
        {
            Debug.Log("Moving Object");
            // Move towards the target position
            transform.localPosition = Vector3.Lerp(transform.localPosition, localTargetPosition, Time.deltaTime * speed);
        }
    }
}
