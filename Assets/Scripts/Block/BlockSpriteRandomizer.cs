using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpriteRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] _possibleSprites;

    private SpriteRenderer[] _spriteRenderers;

    private void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        int randomSpriteIndex = Random.Range(0, _possibleSprites.Length);
        Sprite randomSprite = _possibleSprites[randomSpriteIndex];

        foreach (var spriteRenderer in _spriteRenderers)
            spriteRenderer.sprite = randomSprite;
    }
}
