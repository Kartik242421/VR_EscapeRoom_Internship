using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject about;
    public GameObject Option;
    public GameObject start;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);

    }
    public void MissionBrief()
    {
        SceneManager.LoadScene(6);
    }
    public void Aboutbutton()
    {
        Option.SetActive(false);
        start.SetActive(false);
        about.SetActive(true);


    }
    public void ExitButton()
    {
        Application.Quit();

    }
    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void OptionButton()
    {
        Option.SetActive(true);
        start.SetActive(false);
        about.SetActive(false);
        Debug.Log("Clicked");
    }
    public void abouttomain()
    {
        Option.SetActive(false);
        start.SetActive(true);
        about.SetActive(false);
    }
}
