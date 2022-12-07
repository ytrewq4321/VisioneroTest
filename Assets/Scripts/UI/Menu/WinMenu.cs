using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //MenuManager.Instance.PauseGame();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
