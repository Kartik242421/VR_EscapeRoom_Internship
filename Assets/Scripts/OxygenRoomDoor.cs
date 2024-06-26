using UnityEngine;

public class OxygenRoomDoor : MonoBehaviour
{
    public Vector3 localTargetPosition; 
    public float speed = 2.0f; 

    
    public bool isMovingToTarget = false;

    //private AudioSource audioSource; // Audio source component

    void Start()
    {
        //audioSource = GetComponent<AudioSource>(); // Get the audio source component
    }

    void Update()
    {
        if (isMovingToTarget)
        {
            Debug.Log("Moving Object....");
            // Move towards the target position
            transform.localPosition = Vector3.Lerp(transform.localPosition, localTargetPosition, Time.deltaTime * speed);
        }
        
    }
}
