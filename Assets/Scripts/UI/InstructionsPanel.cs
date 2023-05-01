using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPanel : UIPanel
{

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnNewGameStarted += ShowPanel;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnNewGameStarted -= ShowPanel;
    }

    public void ContinueGame()
    {
        _gameManager.Events.StartLevel(0);
        HidePanel();
    }
}
