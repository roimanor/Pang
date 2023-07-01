using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject androidButtons;

    [SerializeField] private bool debugAndroid;

    private void Start()
    {
        androidButtons.SetActive(Application.platform == RuntimePlatform.Android || debugAndroid);
    }

    private void Update()
    {
        timerText.text = GameManager.Instance.Timer.ToString("000");
    }
}
