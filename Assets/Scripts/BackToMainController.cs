using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainController : MonoBehaviour
{
    public void OnMainmenuClick()
    {
        SceneManager.LoadScene("Main menu");
    }

}
