using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static string PreviousSceneName { get; private set; }

    private void Awake()
    {
        // Ensure this object persists across scenes
        DontDestroyOnLoad(gameObject);

        // Additional setup can be added here if needed
    }

    public static void LoadScene(string sceneName)
    {
        PreviousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public static void RestartPreviousScene()
    {
        if (!string.IsNullOrEmpty(PreviousSceneName))
        {
            SceneManager.LoadScene(PreviousSceneName);
        }
        else
        {
            Debug.LogWarning("Previous scene name is not set.");
        }
    }
}
