using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    public float maxIntensity = 2f;
    public float intensityIncreaseSpeed = 0.1f;

    private Light[] childLights;

    void Start()
    {

        childLights = GetComponentsInChildren<Light>();
        foreach (Light light in childLights)
        {
            light.intensity = 0f;
        }
    }

    void Update()
    {
        foreach (Light light in childLights)
        {

            if (light.intensity < maxIntensity)
            {
                light.intensity += intensityIncreaseSpeed * Time.deltaTime;
                if (light.intensity > maxIntensity)
                {
                    light.intensity = maxIntensity;
                }
            }
        }
    }
}