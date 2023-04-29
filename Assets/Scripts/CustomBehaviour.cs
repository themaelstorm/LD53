using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    private GameManager _gameManager;

    public virtual void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
}
