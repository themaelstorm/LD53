using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : CustomBehaviour
{
    [SerializeField] private UIManager _uiManager;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);
        _uiManager = gameManager.UI;
        HidePanel();

    }

    public virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
