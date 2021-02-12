using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        GameSceneManager.LoadNextScene();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
