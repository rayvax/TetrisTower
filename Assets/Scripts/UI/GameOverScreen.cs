using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private string _scoreTextLabel;
    [Space]
    [SerializeField] private Player _player;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    private void OnEnable()
    {
        _player.Dead += OnPlayerDead;
        _replayButton.onClick.AddListener(OnReplayButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDead;
        _replayButton.onClick.RemoveListener(OnReplayButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }

    private void OnPlayerDead()
    {
        OpenScreen();
        _scoreText.text = _scoreTextLabel + _player.Score;
    }

    private void OnReplayButtonClick()
    {
        Time.timeScale = 1;
        GameSceneLoader.ReloadScene();
    }

    private void OnMainMenuButtonClick()
    {
        Time.timeScale = 1;
        GameSceneLoader.LoadMainMenu();
    }

    private void OpenScreen()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        Time.timeScale = 0;
    }
}
