using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private BlockShredder _blockShredder;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Dead;

    public int MaxHealth => _maxHealth;
    public int Score => _score;

    private int _currentHealth;
    private int _score;

    private void OnEnable()
    {
        _blockShredder.BlockEntered += OnBlockFellOut;
        _blockSpawner.BlockSpawned += OnBlockSpawned;
    }

    private void OnDisable()
    {
        _blockShredder.BlockEntered -= OnBlockFellOut;
        _blockSpawner.BlockSpawned -= OnBlockSpawned;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _score = 0;
    }

    private void OnBlockSpawned(Block block)
    {
        block.BlockPlaced += AddScore;
    }

    private void AddScore(Block block)
    {
        block.BlockPlaced -= AddScore;
        _score++;
    }

    private void OnBlockFellOut(Block block)
    {
        if(block.IsPlaced)
            _score--;

        TakeDamage();
    }

    private void TakeDamage()
    {
        if (_currentHealth > 0)
        {
            _currentHealth--;
            HealthChanged?.Invoke(_currentHealth);
        }


        if (_currentHealth <= 0)
            Dead?.Invoke();
    }
}
