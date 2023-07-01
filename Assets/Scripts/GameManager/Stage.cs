using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Stage", menuName = "Pang/Stage", order = 1)]
public class Stage : ScriptableObject
{
    /// <summary>
    /// Represents a game stage
    /// </summary>
    public float timeToCompleteStage;
    public List<BubbleSetup> bubblesSetup;
    public Stage nextStage;
}

[Serializable]
public struct BubbleSetup
{
    public BubbleInitialModel bubble;
    public Vector2 startPos;
}
