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
