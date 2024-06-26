using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.SceneManagement;  // Required for scene management

public class WheelWorking : MonoBehaviour
{
    public AudioSource voice1;
    public AudioSource voice2;
    public XRKnob wheel1;
    //private bool isWheel1Activated;

    void Start()
    {
        wheel1.value = 0.0f;
        //isWheel1Activated = false;
    }

    void Update()
    {
        if (wheel1.value >= 1)
        {
            OnWheelStateChanged();
        }
    }

    private void OnWheelStateChanged()
    {
        voice1.Play();
        voice2.Play();
        Debug.Log("Oxygen regenerated ____");
        StartCoroutine(ChangeLevelAfterDelay(15f));  // Start the coroutine
    }

    private IEnumerator ChangeLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(5);
    }
}
