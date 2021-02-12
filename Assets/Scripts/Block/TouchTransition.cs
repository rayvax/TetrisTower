using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTransition : Transition
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        NeedTransit = true;
    }
}
