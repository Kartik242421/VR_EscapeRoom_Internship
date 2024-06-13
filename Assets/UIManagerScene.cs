using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScene : MonoBehaviour
{
    public GameObject task1;
    public GameObject task2;
    public GameObject task21;
    public GameObject allow;
    public GameObject buttonui;
    public GameObject lever1ui;
    public GameObject lever2ui;
    void Start()
    {
        
    }

    public void FirstTask()
    {
        task1.SetActive(false);
        allow.SetActive(true);
    }
    public void SecondTask()
    {
        task2.SetActive(false);
        task21.SetActive(false);
        allow.SetActive(true);
    }
    public void buttonpressed()
    {
        buttonui.SetActive(false);
        lever1ui.SetActive(false);
        lever2ui.SetActive(false);
    }
}
