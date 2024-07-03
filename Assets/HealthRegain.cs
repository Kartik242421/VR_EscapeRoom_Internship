using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HealthManager.Instance.ChangeHealth(100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
