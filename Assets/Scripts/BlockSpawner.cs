using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnedBlockContainer;
    [SerializeField] private List<Block> _blockTemplates;
    [Space]
    [SerializeField] private BlockShredder _blockShredder;
    [SerializeField] private BlockFreezer _blockFreezer;
    
    public event UnityAction<Block> BlockSpawned;

    public List<Block> PlacedBlocks => _placedBlocks;

    private List<Block> _placedBlocks = new List<Block>();
    

    private void OnEnable()
    {
        _blockShredder.BlockEntered += OnBlockFellOut;
        _blockFreezer.PlacedBlocksFroze += OnPlacedBlocksFroze;
    }

    private void OnDisable()
    {
        _blockShredder.BlockEntered -= OnBlockFellOut;
        _blockFreezer.PlacedBlocksFroze -= OnPlacedBlocksFroze;
    }

    private void Start()
    {
        Spawn(GetRandomBlockTemplate());
    }

    private void Spawn(Block blockTemplate)
    {
        var spawnedBlock = Instantiate(blockTemplate, transform.position, Quaternion.identity, _spawnedBlockContainer);
        BlockSpawned?.Invoke(spawnedBlock);
        spawnedBlock.BlockPlaced += OnBlockPlaced;
    }

    private Block GetRandomBlockTemplate()
    {
        int randomIndex = Random.Range(0, _blockTemplates.Count);
        return _blockTemplates[randomIndex];
    }

    private void OnBlockPlaced(Block block)
    {
        block.BlockPlaced -= OnBlockPlaced;
        Spawn(GetRandomBlockTemplate());

        _placedBlocks.Add(block);
    }

    private void OnBlockFellOut(Block block)
    {
        if(!block.IsPlaced)
            Spawn(GetRandomBlockTemplate());
    }

    private void OnPlacedBlocksFroze()
    {
        _placedBlocks.Clear();
    }
}
