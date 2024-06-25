using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelnumber;
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelnumber);
    }
}
    