using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class DefenceSystem : MonoBehaviour
{
    public XRLever lever1; 
    public XRLever lever2;

    public GameObject uiLever1Off;
    public GameObject uiLever1On; 
    public GameObject uiLever2Off; 
    public GameObject uiLever2On; 


    public GameObject defenceButton;
    private bool isLever1Activated;
    private bool isLever2Activated;

    // Start is called before the first frame update
    void Start()
    {
        uiLever1Off.SetActive(true);
        uiLever2Off.SetActive(true);

        defenceButton.SetActive(false);
        // Initialize the lever states
        isLever1Activated = lever1.value;
        isLever2Activated = lever2.value;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if lever1 state has changed
        if (lever1.value != isLever1Activated)
        {
            isLever1Activated = lever1.value;
            uiLever1Off.SetActive(false);
            uiLever1On.SetActive(true);

            OnLeverStateChanged(lever1, isLever1Activated);
        }

        // Check if lever2 state has changed
        if (lever2.value != isLever2Activated)
        {
            isLever2Activated = lever2.value;
            uiLever2Off.SetActive(false);
            uiLever2On.SetActive(true);
            OnLeverStateChanged(lever2, isLever2Activated);
        }

        // Check if both levers are on
        if (isLever1Activated && isLever2Activated)
        {
            ActivateDefenceSystem();
        }
        /*else
        {
            DeactivateDefenceSystem();
        }*/
    }

    private void OnLeverStateChanged(XRLever lever, bool isOn)
    {
        if (lever == lever1)
        {
            Debug.Log(isOn ? "Lever 1 activated!" : "Lever 1 deactivated!");
           
        }
        else if (lever == lever2)
        {
            Debug.Log(isOn ? "Lever 2 activated!" : "Lever 2 deactivated!");
        }
    }

    private void ActivateDefenceSystem()
    {
        defenceButton.SetActive(true);

        //Debug.Log("Defence system activated!");
    }

    private void DeactivateDefenceSystem()
    {
        Debug.Log("Defence system deactivated!");
    }
}
