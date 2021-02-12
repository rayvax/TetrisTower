using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelThreshold : MonoBehaviour
{
    [SerializeField] private ThresholdLine _thresholdLine;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private CanvasGroupFadeEffect _fadeEffect;

    public event UnityAction<LevelThreshold> LevelReached;

    private void OnEnable()
    {
        _thresholdLine.PlacedBlockCrossedLine += OnPlacedBlockCrossedLine;
    }

    private void OnDisable()
    {
        _thresholdLine.PlacedBlockCrossedLine -= OnPlacedBlockCrossedLine;
    }

    private void Start()
    {
        _fadeEffect.FadeIn();
    }

    public void Init(int level)
    {
        _label.text = "Level " + level;
    }

    private void OnPlacedBlockCrossedLine()
    {
        LevelReached?.Invoke(this);
        _fadeEffect.FadeOut();
        Destroy(gameObject, _fadeEffect.FadeTime);
    }
}
