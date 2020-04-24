using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void StartGame()
    {
        SceneManager.LoadScene("Labo");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("pause");
        Time.timeScale = 1.0f;
        pauseCanvas.SetActive(false);
    }
}
