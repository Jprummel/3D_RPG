using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
