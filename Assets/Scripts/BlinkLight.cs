using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour
{
    public GameObject targetObject; // The object to enable/disable
    public float blinkInterval = 0.5f; // Interval at which the object blinks

    void Start()
    {
        if (targetObject == null)
        {
            targetObject = gameObject; // Default to the GameObject this script is attached to
        }

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);
            targetObject.SetActive(!targetObject.activeSelf); // Toggle the active state
        }
    }
}
