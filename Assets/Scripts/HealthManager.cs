using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    private Image healthBarImage;
    private Image oxygenBarImage;

    public float currentHealth;
    private float maxHealth = 100f;

    public float currentOxygen;
    private float maxOxygen = 100f;

    [SerializeField]
    private float lerpDuration = 0.5f;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    public float CurrentOxygen
    {
        get { return currentOxygen; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Find the health bar image by tag
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        if (healthBarObject != null)
        {
            healthBarImage = healthBarObject.GetComponent<Image>();
            if (healthBarImage.type != Image.Type.Filled)
            {
                Debug.LogError("Health bar image found, but it is not set to 'Filled' type.");
                healthBarImage = null;
            }
        }
        else
        {
            Debug.LogError("Health bar image with tag 'HealthBar' not found.");
        }

        // Find the oxygen bar image by tag
        GameObject oxygenBarObject = GameObject.FindGameObjectWithTag("OxygenBar");
        if (oxygenBarObject != null)
        {
            oxygenBarImage = oxygenBarObject.GetComponent<Image>();
            if (oxygenBarImage.type != Image.Type.Filled)
            {
                Debug.LogError("Oxygen bar image found, but it is not set to 'Filled' type.");
                oxygenBarImage = null;
            }
        }
        else
        {
            Debug.LogError("Oxygen bar image with tag 'OxygenBar' not found.");
        }
    }

    private void Start()
    {
        //currentHealth = maxHealth;
        //currentOxygen = maxOxygen;
        UpdateHealthBar();
        UpdateOxygenBar();
    }

    // Call this function to change health
    public void ChangeHealth(float amount)
    {
        float newHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        StartCoroutine(SmoothChangeHealth(newHealth));
    }

    // Call this function to change oxygen
    public void ChangeOxygen(float amount)
    {
        float newOxygen = Mathf.Clamp(currentOxygen + amount, 0, maxOxygen);
        StartCoroutine(SmoothChangeOxygen(newOxygen));
    }

    private IEnumerator SmoothChangeHealth(float targetHealth)
    {
        float elapsedTime = 0f;
        float startHealth = currentHealth;

        while (elapsedTime < lerpDuration)
        {
            currentHealth = Mathf.Lerp(startHealth, targetHealth, elapsedTime / lerpDuration);
            UpdateHealthBar();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentHealth = targetHealth;
        UpdateHealthBar();
    }

    private IEnumerator SmoothChangeOxygen(float targetOxygen)
    {
        float elapsedTime = 0f;
        float startOxygen = currentOxygen;

        while (elapsedTime < lerpDuration)
        {
            currentOxygen = Mathf.Lerp(startOxygen, targetOxygen, elapsedTime / lerpDuration);
            UpdateOxygenBar();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentOxygen = targetOxygen;
        UpdateOxygenBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }

    private void UpdateOxygenBar()
    {
        if (oxygenBarImage != null)
        {
            oxygenBarImage.fillAmount = currentOxygen / maxOxygen;
        }
    }
}
