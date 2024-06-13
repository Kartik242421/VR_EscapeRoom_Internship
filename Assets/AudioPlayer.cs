using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Assign the audio clip in the inspector
    public AudioClip triggerSound;

    // Reference to the audio source component
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the GameObject if it doesn't already have one
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = triggerSound;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
