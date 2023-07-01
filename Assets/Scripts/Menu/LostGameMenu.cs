using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LostGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    private void OnEnable()
    {
        if(GameManager.Instance)
            pointsText.text = GameManager.Instance.Points.ToString();
    }
}
