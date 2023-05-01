using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePanel : UIPanel
{
    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnLevelLoaded += ShowPanel;
        _gameManager.Events.OnLevelFailed += HidePanel;
        _gameManager.Events.OnLevelCompleted += HidePanel;

    }

    private void OnDestroy()
    {
        _gameManager.Events.OnLevelLoaded -= ShowPanel;
        _gameManager.Events.OnLevelFailed -= HidePanel;
        _gameManager.Events.OnLevelCompleted -= HidePanel;
    }

    public void Pause()
    {
        _gameManager.PauseGame();
    }

    public void Resume()
    {
        _gameManager.ResumeGame();
    }


}
