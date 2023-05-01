using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UIPanel
{
    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnGameStarted += ShowPanel;
        _gameManager.Events.OnNewGameStarted += HidePanel;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnGameStarted -= ShowPanel;
        _gameManager.Events.OnNewGameStarted -= HidePanel;
    }

    public void OpenCredits()
    {
        _gameManager.Events.ShowCredits();
    }

    public void StartNewGame()
    {
        _gameManager.Events.StartNewGame();
    }
}
