using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        //ADD SOUND EFFECT
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}