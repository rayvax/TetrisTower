using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BlockPlacedState), typeof(Rigidbody2D))]
public class Block : MonoBehaviour
{
    [SerializeField] private Color _onFrozenColor;
    [SerializeField] private ParticleSystem _popUpVFX;
    [SerializeField] private float _popUpVFXDestroyDelay;

    public event UnityAction<Block> BlockPlaced;

    public bool IsPlaced => _blockPlacedState.enabled;
    public bool IsFrozen => _rigidbody2D.bodyType == RigidbodyType2D.Static;

    private BlockPlacedState _blockPlacedState;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _blockPlacedState = GetComponent<BlockPlacedState>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _blockPlacedState.BlockPlaced += OnBlockPlaced;
    }

    private void OnDisable()
    {
        _blockPlacedState.BlockPlaced -= OnBlockPlaced;
    }

    private void Start()
    {
        MakePopUpEffect();
    }

    private void MakePopUpEffect()
    {
        var vfx = Instantiate(_popUpVFX, transform);
        Destroy(vfx, _popUpVFXDestroyDelay);
    }

    public void Freeze()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;

        var blockSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in blockSprites)
            sprite.color = _onFrozenColor;
    }

    private void OnBlockPlaced()
    {
        BlockPlaced?.Invoke(this);
    }
}
