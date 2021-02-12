using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCameraTransition : Transition
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var blockOnScreenPosition = _camera.WorldToViewportPoint(transform.position);
        if (blockOnScreenPosition.x < 0 || blockOnScreenPosition.x > 1 || blockOnScreenPosition.y < 0)
            NeedTransit = true;
    }
}
