using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble", menuName = "Pang/Bubble", order = 1)]
public class BubbleInitialModel : ScriptableObject
{
    public float bounceForce = 10f;
    public float startXVelocity = 3;
    public float bubbleSize = 5f;
    public int healthRemaining = 3;
    public float BounceMultiplicand = .85f;
}
