using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowView : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [Header("Value")]
    [SerializeField] private Color color;


    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }
}
