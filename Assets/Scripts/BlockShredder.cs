using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockShredder : MonoBehaviour
{
    [SerializeField] private LevelThresholdSpawner _thresholdSpawner;
    [SerializeField] private Vector3 _offsetFromLevelThreshold;

    public event UnityAction<Block> BlockEntered;

    private void OnEnable()
    {
        _thresholdSpawner.ThresholdReached += OnLevelThresholdReached;
    }

    private void OnDisable()
    {
        _thresholdSpawner.ThresholdReached -= OnLevelThresholdReached;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Block block))
        {
            if (!block.IsFrozen)
            {
                BlockEntered?.Invoke(block);
                Destroy(block.gameObject);
            }
        }
    }

    private void OnLevelThresholdReached(LevelThreshold levelThreshold)
    {
        transform.position = levelThreshold.transform.position + _offsetFromLevelThreshold;
    }
}
