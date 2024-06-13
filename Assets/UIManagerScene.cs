using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScene : MonoBehaviour
{
    public GameObject task1;
    public GameObject allow;
    void Start()
    {
        
    }

    public void FirstTask()
    {
        task1.SetActive(false);
        allow.SetActive(true);

    }
}
