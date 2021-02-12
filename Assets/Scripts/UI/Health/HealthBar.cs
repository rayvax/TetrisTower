using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heart _heartTemplate;
    [SerializeField] private Player _player;

    private List<Heart> _aliveHearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        SetAliveHearts(_player.MaxHealth);
    }

    private void SetAliveHearts(int ammount)
    {
        _aliveHearts.Clear();
        for (int i = 0; i < ammount; i++)
            CreateHeart();
    }

    private void OnHealthChanged(int currentHealth)
    {
        int excessHeartsCount = _aliveHearts.Count - currentHealth;

        if (excessHeartsCount < 0)
        {
            for (int i = 0; i > excessHeartsCount; i--)
                CreateHeart();
        }
        else
        {
            for (int i = 0; i < excessHeartsCount; i++)
                DestroyHeart(_aliveHearts.Count - 1);
        }
    }

    private void CreateHeart()
    {
        Heart heart = Instantiate(_heartTemplate, transform);
        _aliveHearts.Add(heart);
    }

    private void DestroyHeart(int index)
    {
        _aliveHearts[index].Die();
        _aliveHearts.RemoveAt(index);
    }
}
