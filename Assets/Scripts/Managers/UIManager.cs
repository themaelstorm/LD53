using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : CustomBehaviour
{
    [SerializeField] private UIPanel[] Panels;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        foreach (var panel in Panels) 
        {
            panel.Init(gameManager);
        }
    }
}
