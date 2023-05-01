using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePanel : UIPanel
{
    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnLevelCompleted += ShowPanel;

    }

    public void NextLevel()
    {
        _gameManager.Levels.PlayNextLevel();
        HidePanel();
    }
}
