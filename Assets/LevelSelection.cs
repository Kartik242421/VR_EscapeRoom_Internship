using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(int levelName)
    {
            SceneManager.LoadScene(levelName);
    }
}
