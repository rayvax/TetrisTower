using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockFreezer : MonoBehaviour
{
    [SerializeField] private LevelThresholdSpawner _thresholdSpawner;
    [SerializeField] private BlockSpawner _blockSpawner;

    public event UnityAction PlacedBlocksFroze;

    private void OnEnable()
    {
        _thresholdSpawner.ThresholdReached += FreezePlacedBlocks;
    }

    private void OnDisable()
    {
        _thresholdSpawner.ThresholdReached -= FreezePlacedBlocks;
    }

    private void FreezePlacedBlocks(LevelThreshold levelThreshold)
    {
        var placedBlocks = _blockSpawner.PlacedBlocks;

        foreach (var block in placedBlocks)
        {
            if (block != null)
                block.Freeze();
        }
    }
}
