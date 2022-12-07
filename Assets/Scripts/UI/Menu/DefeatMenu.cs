using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
