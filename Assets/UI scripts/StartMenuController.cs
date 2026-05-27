using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleSceneTestCopy"); // moet nog veranderen met defenitieve scene
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
