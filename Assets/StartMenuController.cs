using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        // Load the main game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void OnMainmenuClick()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void OnExitClick()
    {
        // Exit the application
        Application.Quit();
        
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    

}
