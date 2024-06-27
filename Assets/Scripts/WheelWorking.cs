using System.Collections;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.SceneManagement;

public class WheelWorking : MonoBehaviour
{
    public AudioSource voice1;
    public AudioSource voice2;
    public XRKnob wheel1;
    private bool isWheel1Activated;
    public GameObject timerui;
    public GameObject timerScript;

    void Start()
    {
        wheel1.value = 0.0f;
        isWheel1Activated = false; // Initialize the flag to false
    }

    void Update()
    {
        if (wheel1.value >= 1 && !isWheel1Activated)
        {
            wheel1.value = 1f;
            OnWheelStateChanged();
            isWheel1Activated = true; // Set the flag to true after the function is called
        }
    }

    private void OnWheelStateChanged()
    {
        voice1.Play();
        voice2.Play();
        timerScript.SetActive(false);
        timerui.SetActive(false);
        Debug.Log("Oxygen regenerated __");
        StartCoroutine(ChangeLevelAfterDelay(60f));
    }

    private IEnumerator ChangeLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(5);
    }
}