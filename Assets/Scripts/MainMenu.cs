using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update() {
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene("Menu");
        }
    }

    public void PlayApp() {
        SceneManager.LoadScene("Level01");
    }
    public void AppQuit() {
        Application.Quit();
    }
    public void AppMenu() {
        SceneManager.LoadScene("Menu");
    }
}
