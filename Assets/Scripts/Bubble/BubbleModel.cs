using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BubbleModel : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 10f;
    public float BounceForce => _bounceForce;

    [SerializeField] private float _startXVelocity = 3;
    public float StartXVelocity => _startXVelocity;

    [SerializeField] private float _bubbleSize = 5f;
    public float BubbleSize => _bubbleSize;

    [SerializeField] private int _healthRemaining = 3;
    public int HealthRemaining => _healthRemaining;

    [SerializeField] private float _bounceMultiplicand = .85f;
    public float BounceMultiplicand => _bounceMultiplicand;

    public void Initialize(float bounceForce, float startXVelocity, float bubbleSize, int healthRemaining, float bounceMultiplicand)
    {
        _bounceForce = bounceForce;
        _startXVelocity = startXVelocity;
        _bubbleSize = Mathf.Clamp(bubbleSize, 1f, 10f);
        _healthRemaining = healthRemaining;
        _bounceMultiplicand = bounceMultiplicand;

    }

    public void Initialize(BubbleInitialModel bubbleInitialModel)
    {
        Initialize(bubbleInitialModel.bounceForce, bubbleInitialModel.startXVelocity, bubbleInitialModel.bubbleSize, bubbleInitialModel.healthRemaining, bubbleInitialModel.BounceMultiplicand);
    }

}
