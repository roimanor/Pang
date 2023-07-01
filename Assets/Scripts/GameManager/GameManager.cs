using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Stage startStage;
    [SerializeField] private Stage currentStage;
    [SerializeField] private int activeBubbles;
    
    private bool gameRunning;
    private float _timer;
    public float Timer => _timer;

    private int _points = 0;
    public float Points => _points;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (gameRunning)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
                QuitToMenu();
        }
    }

    public void StartGame()
    {
        currentStage = startStage;
        _points = 0;
        MenuController.Instance.ShowInGameMenu();
        gameRunning = true;
        LoadStage();
    }

    public void NextStage()
    {
        MenuController.Instance.ShowInGameMenu();
        gameRunning = true;
        LoadStage();
    }

    private void LoadStage()
    {
        Assert.IsNotNull(currentStage);
        _timer = currentStage.timeToCompleteStage;
        BubblePoolManager.Instance.ReleaseAll();
        activeBubbles = 0;
        foreach (BubbleSetup bubbleSetup in currentStage.bubblesSetup)
        {
            GameObject bubbleGO = BubblePoolManager.Instance.GetPooledObject();
            bubbleGO.transform.position = bubbleSetup.startPos;
            bubbleGO.GetComponent<BubbleModel>().Initialize(bubbleSetup.bubble);
            bubbleGO.SetActive(true);
            activeBubbles++;
        }
    }

    private void FinishStage()
    {
        if (currentStage.nextStage == null)
        {
            EndGame();
            return;
        }
        currentStage = currentStage.nextStage;
        gameRunning = false;
        MenuController.Instance.ShowFinishStageMenu();
    }

    public void EndGame()
    {
        MenuController.Instance.ShowLostStageMenu();
    }

    public void QuitToMenu()
    {
        gameRunning = false;
        MenuController.Instance.ShowMainMenu();
    }

    public void DestroyBubble()
    {
        _points += 200;
        activeBubbles--;
        if (activeBubbles == 0)
            FinishStage();
    }

    public void AddBubble()
    {
        activeBubbles++;
    }
}
