using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light warningLight;  // The light component that will blink
    public float blinkInterval = 0.5f;  // The interval between blinks

    private float nextBlinkTime;

    void Start()
    {
        if (warningLight == null)
        {
            warningLight = GetComponent<Light>();
        }

        if (warningLight == null)
        {
            Debug.LogError("No Light component found on this GameObject. Please attach a Light component or assign one in the inspector.");
            enabled = false;
            return;
        }

        nextBlinkTime = Time.time + blinkInterval;
    }

    void Update()
    {
        if (Time.time >= nextBlinkTime)
        {
            warningLight.enabled = !warningLight.enabled;  // Toggle the light's enabled state
            nextBlinkTime = Time.time + blinkInterval;
        }
    }
}
