using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}