using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Continue()
    {
        MenuManager.Instance.PausedGame.Invoke();
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuManager.Instance.PausedGame.Invoke();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
