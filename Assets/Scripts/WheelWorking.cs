using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class WheelWorking : MonoBehaviour
{
    public XRKnob wheel1;
    private bool isWheel1Activated;

    void Start()
    {
        wheel1.value = 0.0f;
        isWheel1Activated = false;
    }

    void Update()
    {
        if(wheel1.value >= 1){
            OnWheelStateChanged();
        }
        
    }

    private void OnWheelStateChanged(){
        Debug.Log("Oxygen regenerated ____");
    }
}

    
