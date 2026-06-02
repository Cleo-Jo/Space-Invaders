using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main menu");
    }
}
