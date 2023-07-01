using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPlacer : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject borderParent;

    [Header("References")]
    [SerializeField] private RectTransform leftBorder;
    [SerializeField] private RectTransform topBorder;
    [SerializeField] private RectTransform bottomBorder;
    [SerializeField] private RectTransform rightBorder;

    private void Start()
    {
        PlaceBorders();
    }

    [ContextMenu("Place Borders")]
    public void PlaceBorders()
    {
        borderParent.SetActive(true);

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        leftBorder.position = new Vector3(-width / 2, 0f, 0f);
        leftBorder.localScale = new Vector3(1f, height, 0f);

        topBorder.position = new Vector3(0f, height / 2, 0f);
        topBorder.localScale = new Vector3(width, 1f, 0f);

        bottomBorder.position = new Vector3(0f, - height / 2, 0f);
        bottomBorder.localScale = new Vector3(width, 1f, 0f);

        rightBorder.position = new Vector3(width / 2, 0f, 0f);
        rightBorder.localScale = new Vector3(1f, height, 0f);
    }

    

    
}
