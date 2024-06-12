using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light warningLight;
    public float blinkInterval = 0.5f;

    private float timer;

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
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            warningLight.enabled = !warningLight.enabled;
            timer = 0f;
        }
    }
}
