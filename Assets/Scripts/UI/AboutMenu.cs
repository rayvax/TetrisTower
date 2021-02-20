using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutMenu : MonoBehaviour
{
    [SerializeField] private Button _backButton;


    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClick);
    }
    private void OnBackButtonClick()
    {
        GameSceneLoader.LoadMainMenu();
    }
}
