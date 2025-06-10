using UnityEngine;
using UnityEngine.SceneManagement;

public class Dteahscene : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Start");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
