using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Die()
    {
        _animator.SetTrigger("Disappear");
        Destroy(gameObject, _destroyDelay);
    }
}
