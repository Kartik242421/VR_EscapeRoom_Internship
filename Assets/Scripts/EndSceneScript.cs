using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public string homeSceneName = "UI"; // Name of the home page scene
    public Button restartButton; // Reference to the Restart Button
    public Button homeButton; // Reference to the Home Button

    void Start()
    {
        // Add listener for restart button
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartPreviousLevel);
        }

        // Add listener for home button
        if (homeButton != null)
        {
            homeButton.onClick.AddListener(GoToHomePage);
        }
    }

    void RestartPreviousLevel()
    {
        SceneTransitionManager.RestartPreviousScene(); // Restart the previous level
    }

    void GoToHomePage()
    {
        SceneTransitionManager.LoadScene(homeSceneName); // Load the home page scene
    }
}
