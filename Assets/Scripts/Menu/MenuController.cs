using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    /// <summary>
    /// I would normally use a state machine, but couldn't find an implementation, and was strapped for time.
    /// </summary>
    public static MenuController Instance;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject LostGameMenu;
    [SerializeField] private GameObject FinishStageMenu;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ShowMainMenu();
    }

    public void StartGameButton()
    {
        GameManager.Instance.StartGame();
    }

    public void NextStageButton()
    {
        GameManager.Instance.NextStage();
    }

    public void Quit()
    {
        Application.Quit();
    }

    [ContextMenu("Show main menu")]
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        InGameMenu.SetActive(false);
        LostGameMenu.SetActive(false);
        FinishStageMenu.SetActive(false);
    }

    [ContextMenu("Show in game menu")]
    public void ShowInGameMenu()
    {
        mainMenu.SetActive(false);
        InGameMenu.SetActive(true);
        LostGameMenu.SetActive(false);
        FinishStageMenu.SetActive(false);
    }

    [ContextMenu("Show finish stage menu")]
    public void ShowFinishStageMenu()
    {
        mainMenu.SetActive(false);
        InGameMenu.SetActive(false);
        LostGameMenu.SetActive(false);
        FinishStageMenu.SetActive(true);
    }

    public void ShowLostStageMenu()
    {
        mainMenu.SetActive(false);
        InGameMenu.SetActive(false);
        LostGameMenu.SetActive(true);
        FinishStageMenu.SetActive(false);
    }
}
