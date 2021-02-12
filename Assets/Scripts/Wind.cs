using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float _blowForce;
    [SerializeField] private float _blowPeriod;
    [SerializeField] private float _windDensity;
    [SerializeField] private float _blowDistance;
    [SerializeField] private float _windAreaRadius;
    [SerializeField] private WindDirection _windDirection;
    [SerializeField] private LayerMask _windAffectedLayer;

    private float _elapsedTime;
    private Vector2 _windDirectionVector;

    private enum WindDirection
    {
        Right,
        Left
    }

    private void OnValidate()
    {
        switch(_windDirection)
        {
            case WindDirection.Right:
                _windDirectionVector = Vector2.right;
                break;
            case WindDirection.Left:
                _windDirectionVector = Vector2.left;
                break;
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _blowPeriod)
        {
            _elapsedTime = 0;
            MakeWindBlows();
        }
    }

    private void MakeWindBlows()
    {
        float maxWindPositionY = transform.position.y + _windAreaRadius;
        float minWindPositionY = transform.position.y - _windAreaRadius;
        float distanceBetweenBlows = (maxWindPositionY - minWindPositionY) / _windDensity;

        for (float originPositionY = minWindPositionY; originPositionY < maxWindPositionY; originPositionY += distanceBetweenBlows)
            MakeOneBlow(originPositionY);
    }
    
    private void MakeOneBlow(float originPositionY)
    {
        var originPosition = new Vector2(transform.position.x, originPositionY);
        var rayHit = Physics2D.Raycast(originPosition, _windDirectionVector, _blowDistance, _windAffectedLayer.value);

        var affectedRigidbody = rayHit.rigidbody;
        if(affectedRigidbody != null && affectedRigidbody.TryGetComponent(out Block block))
        {
            if(block.IsPlaced)
                affectedRigidbody.AddForce(_windDirectionVector * _blowForce);
        }
    }
}
