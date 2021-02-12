using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour
{
    public static void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public static void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
