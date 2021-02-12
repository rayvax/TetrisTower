using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected PlayerInputMap PlayerInput;

    public void Enter(PlayerInputMap playerInput)
    {
        if(!enabled)
        {
            PlayerInput = playerInput;
            enabled = true;

            foreach (var transition in _transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled)
        { 
            enabled = false;

            foreach (var transition in _transitions)
                transition.enabled = false;
        }
    }

    public State GetNextState()
    {
        if(enabled)
        {
            foreach (var transition in _transitions)
            {

                if (transition.NeedTransit)
                    return transition.TargetState;

            }
        }

        return null;
    }
}
