using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : UIPanel
{

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnCreditsShown += ShowPanel;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnCreditsShown -= ShowPanel;
    }

    public void Close()
    {
        HidePanel();
    }

}
