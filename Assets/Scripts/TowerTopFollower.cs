using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTopFollower : MonoBehaviour
{
    [SerializeField] private LevelThresholdSpawner _thresholdSpawner;
    [SerializeField] private BlockSpawner _blockSpawner;

    private void OnEnable()
    {
        _blockSpawner.BlockSpawned += OnBlockSpawned;
    }

    private void OnDisable()
    {
        _blockSpawner.BlockSpawned -= OnBlockSpawned;
    }

    private void Start()
    {
        SetPositionToTowerTop(_thresholdSpawner.StartPointY);
    }

    private void SetPositionToTowerTop(float towerTopY)
    {
        transform.position = new Vector3(transform.position.x, 
                                         towerTopY, 
                                         transform.position.z);
    }

    private void OnBlockSpawned(Block spawnedBlock)
    {
        spawnedBlock.BlockPlaced += OnBlockPlaced;
    }

    private void OnBlockPlaced(Block block)
    {
        block.BlockPlaced -= OnBlockPlaced;

        if(transform.position.y < block.transform.position.y)
            SetPositionToTowerTop(block.transform.position.y);
    }
}
