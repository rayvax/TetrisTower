using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private string _playButtonSceneName;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private string _aboutButtonSceneName;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _aboutButton.onClick.AddListener(OnAboutButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _aboutButton.onClick.RemoveListener(OnAboutButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(_playButtonSceneName);
    }

    private void OnAboutButtonClick()
    {
        SceneManager.LoadScene(_aboutButtonSceneName);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
