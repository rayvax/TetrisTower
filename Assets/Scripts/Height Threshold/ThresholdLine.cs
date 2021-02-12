using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ThresholdLine : MonoBehaviour
{
    public event UnityAction PlacedBlockCrossedLine;

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Block block))
        {
            if (block.IsPlaced)
                PlacedBlockCrossedLine?.Invoke();
            else
                block.BlockPlaced += OnBlockPlaced;
        }
    }

    private void OnBlockPlaced(Block block)
    {
        block.BlockPlaced -= OnBlockPlaced;

        if (block.TryGetComponent(out Collider2D blockCollider) && _collider2D.IsTouching(blockCollider))
            PlacedBlockCrossedLine?.Invoke();
    }
}
