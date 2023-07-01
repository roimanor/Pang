using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleModel))]
public class BubbleView : MonoBehaviour
{
    private BubbleModel _bubbleModel;
    private void Awake()
    {
        _bubbleModel = GetComponent<BubbleModel>();
    }

    private void OnEnable()
    {
        transform.localScale = new Vector3(_bubbleModel.BubbleSize, _bubbleModel.BubbleSize, 0f);
    }
}
