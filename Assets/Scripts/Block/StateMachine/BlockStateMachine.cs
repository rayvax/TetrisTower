using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateMachine : MonoBehaviour
{
    [SerializeField] private State _startingState;

    private PlayerInputMap _playerInput;
    private State _currentState;

    private void Awake()
    {
        _playerInput = new PlayerInputMap();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        Transit(_startingState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        if (_currentState)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState)
            _currentState.Enter(_playerInput);
    }
}
