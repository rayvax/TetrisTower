using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelThresholdSpawner : MonoBehaviour
{
    [SerializeField] private LevelThreshold _thresholdTemplate;
    [SerializeField] private float _startPointY;
    [SerializeField] private float _startHeight;
    [SerializeField] private float _heightIncreasement;

    public event UnityAction<LevelThreshold> ThresholdReached;

    public float StartPointY => _startPointY;

    private float _currentThresholdPositionY;
    private float _distanceBetweenThreshold;
    private int _currentLevel;

    private void Awake()
    {
        _currentLevel = 1;
        _distanceBetweenThreshold = _startHeight;
        _currentThresholdPositionY = _startPointY + _distanceBetweenThreshold;
    }

    private void Start()
    {
        SpawnThreshold(_currentThresholdPositionY, _currentLevel);
    }

    private void SpawnThreshold(float positionY, int levelNumber)
    {
        Vector3 thresholdPosition = new Vector3(0, positionY, 0);
        var nextThreshold = Instantiate(_thresholdTemplate, thresholdPosition, Quaternion.identity, transform);

        nextThreshold.Init(levelNumber);
        nextThreshold.LevelReached += OnLevelReached;
    }

    private void OnLevelReached(LevelThreshold levelThreshold)
    {
        levelThreshold.LevelReached -= OnLevelReached;
        ThresholdReached?.Invoke(levelThreshold);

        _currentLevel++;
        _distanceBetweenThreshold += _heightIncreasement;
        _currentThresholdPositionY += _distanceBetweenThreshold;
        SpawnThreshold(_currentThresholdPositionY, _currentLevel);
    }
}
