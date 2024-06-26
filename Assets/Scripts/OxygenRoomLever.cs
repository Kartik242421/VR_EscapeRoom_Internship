using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OxygenRoomLever : MonoBehaviour
{
    public XRLever lever1; 
    public XRLever lever2; 
    public XRLever lever3; 
    public OxygenRoomDoor door; // Reference to the OxygenRoomDoor script

    public GameObject wheelObject;
    private bool isLever1Activated;
    private bool isLever2Activated;
    private bool isLever3Activated;

    // Start is called before the first frame update
    void Start()
    {
        wheelObject.SetActive(false);
        // Initialize the lever states
        isLever1Activated = lever1.value;
        isLever2Activated = lever2.value;
        isLever3Activated = lever3.value;
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

        // Check if lever3 state has changed
        if (lever3.value != isLever3Activated)
        {
            isLever3Activated = lever3.value;
            OnLeverStateChanged(lever3, isLever3Activated);
        }

        if(isLever1Activated){
            door.isMovingToTarget = true;
            Debug.Log("MovingDoor");
        }

        // Check if all levers are on
        if (isLever1Activated && isLever2Activated && isLever3Activated)
        {
            ActivateWheel();
        }
        else
        {
            ActivateWheel();
        }
    }

    private void OnLeverStateChanged(XRLever lever, bool isOn)
    {
        if (lever == lever1)
        {
            Debug.Log(isOn ? "Lever 1 activated!" : "Lever 1 deactivated!");
            //door.isMovingToTarget = isOn;
            //Debug.Log("isMovingToTarget set to: " + door.isMovingToTarget);
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
        //Debug.Log("Defence system activated!");
    }

    private void DeactivateDefenceSystem()
    {
        Debug.Log("Defence system deactivated!");
    }
}
