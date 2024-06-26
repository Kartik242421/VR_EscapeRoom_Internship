using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OxygenRoomLever : MonoBehaviour
{
    public XRLever lever1; 
    public XRLever lever2; 
    public XRLever lever3; 

    public GameObject wheelObject;
    private bool isLever1Activated;
    private bool isLever2Activated;
    private bool isLever3Activated;


    public OxygenRoomDoor door1;
    public OxygenRoomDoor door2;
    public OxygenRoomDoor door3;
    //public AudioSource wheelActivationSound;


    // Start is called before the first frame update
    void Start()
    {
        wheelObject.SetActive(false);
        // Initialize the lever states
        isLever1Activated = lever1.value;
        isLever2Activated = lever2.value;
        isLever3Activated = lever2.value;

    }

    // Update is called once per frame
    void Update()
    {
        // Check if lever1 state has changed
        if (lever1.value != isLever1Activated)
        {
            isLever1Activated = lever1.value;
            OnLeverStateChanged(lever1, isLever1Activated);
        }

        // Check if lever2 state has changed
        if (lever2.value != isLever2Activated)
        {
            isLever2Activated = lever2.value;
            OnLeverStateChanged(lever2, isLever2Activated);
        }

        if (lever3.value != isLever3Activated)
        {
            isLever3Activated = lever3.value;
            OnLeverStateChanged(lever3, isLever3Activated);
        }


        if(isLever1Activated)
        {
            door1.isMovingToTarget = true;
        }
        if(isLever2Activated)
        {
            door2.isMovingToTarget = true;
        }
        if(isLever3Activated)
        {
            door3.isMovingToTarget = true;
        }


        // Check if all levers are on
        if (isLever1Activated && isLever2Activated && isLever3Activated)
        {
            ActivateWheel();
            
        }
      
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
        else if (lever == lever3)
        {
            Debug.Log(isOn ? "Lever 3 activated!" : "Lever 3 deactivated!");
        }
    }

    private void ActivateWheel()
    {
        wheelObject.SetActive(true);
        //wheelActivationSound.Play();
        Debug.Log("Wheel activated");
    }    
}
