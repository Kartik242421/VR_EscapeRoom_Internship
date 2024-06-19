using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string Ttag;
    public UnityEvent<GameObject> trigger;

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == Ttag)
        {
            trigger.Invoke(other.gameObject);
        }
    }

}
