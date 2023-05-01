using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPanel : UIPanel
{
    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnLevelFailed += ShowPanel;
        
    }

    public void PlayAgain()
    {
        _gameManager.Levels.PlayAgain();
        HidePanel();
    }
}
