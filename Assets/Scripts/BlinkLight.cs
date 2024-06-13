using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour
{
    public GameObject targetObject;
    public float blinkInterval = 0.5f;
    public AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.loop = true; 
            audioSource.Play(); 
        }

        if (targetObject == null)
        {
            targetObject = gameObject;
        }

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
