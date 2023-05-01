using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : UIPanel
{

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnCreditsShown += ShowPanel;
        _gameManager.Events.OnCreditsHide += HidePanel;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnCreditsShown -= ShowPanel;
        _gameManager.Events.OnCreditsHide -= HidePanel;
    }

    public void Close()
    {
        _gameManager.Events.HideCredits();
    }
}
