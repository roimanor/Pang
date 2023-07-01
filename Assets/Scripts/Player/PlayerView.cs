using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [Header("Value")]
    [SerializeField] private Color color;

    private void Start()
    {
        float height = 2f * Camera.main.orthographicSize;
        transform.position = new Vector3(0f, -height / 2 + 1, 0f);
    }

    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }
}
