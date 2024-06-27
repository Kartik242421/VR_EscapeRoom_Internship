using UnityEngine;

public class OxygenRoomDoor : MonoBehaviour
{
    public Vector3 localTargetPosition; 
    public float speed = 2.0f; 
    public bool isMovingToTarget = false;

    private AudioSource audioSource;
    private bool audioPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isMovingToTarget)
        {
            if (audioSource != null && !audioPlayed)
            {
                audioSource.Play();
                audioPlayed = true;
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, localTargetPosition, Time.deltaTime * speed);

            if (Vector3.Distance(transform.localPosition, localTargetPosition) < 0.01f)
            {
                isMovingToTarget = false;
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
                audioPlayed = false;
            }
        }
    }
}
