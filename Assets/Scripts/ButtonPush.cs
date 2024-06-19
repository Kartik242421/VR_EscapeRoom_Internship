using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;



public class ButtonPush : MonoBehaviour
{

    public GameObject defenceSystemLight;
    public GameObject warningSoundLight;
    // Start is called before the first frame update
    void Start()
    {
        defenceSystemLight.SetActive(false);

        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => activateDefenceSystem());
    }

    public void activateDefenceSystem()
    {
        warningSoundLight.SetActive(false);
        defenceSystemLight.SetActive(true);
    }
}
