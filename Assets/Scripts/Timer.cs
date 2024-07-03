using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timerDuration = 10f; // Duration of the timer in seconds
    public string endSceneName; // Name of the end scene to load after the timer ends
    public Text timerText; // Reference to the UI Text component

    public bool lvl4;
    public bool lvl2;


    private float timer;

    void Start()
    {
        timer = timerDuration; // Initialize the timer with the duration
        UpdateTimerUI(); // Initialize the timer display
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // Decrease the timer by the time that has passed since the last frame
            UpdateTimerUI(); // Update the timer display
        }
        else
        {
            ChangeScene(); // Change the scene when the timer reaches 0
        }
    }

    void ChangeScene()
    {
        SceneTransitionManager.LoadScene(endSceneName); // Load the end scene
    }

    void UpdateTimerUI()
    {
        int wholeSeconds = Mathf.CeilToInt(timer); // Convert the timer to whole seconds
        if (lvl4)
        {
            HealthManager.Instance.ChangeOxygen(-1);

        }
        if (lvl2)
        {
            HealthManager.Instance.ChangeHealth(-1);

        }
        timerText.text = wholeSeconds.ToString() ; // Update the UI Text component
    }
}
