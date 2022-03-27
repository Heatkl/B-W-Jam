using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void Exit()
    {
        Application.Quit();
    }
    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
