using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class BlockPlacedState : State
{
    [SerializeField] private AudioClip[] _placingSound;
    [SerializeField] [Range(0, 1)] private float _placingSoundVolume = 1;

    public event UnityAction BlockPlaced;

    private void OnEnable()
    {
        BlockPlaced?.Invoke();

        PlayPlacingSFX();
    }

    private void PlayPlacingSFX()
    {
        int clipIndex = Random.Range(0, _placingSound.Length);
        AudioSource.PlayClipAtPoint(_placingSound[clipIndex], transform.position, _placingSoundVolume);
    }
}
