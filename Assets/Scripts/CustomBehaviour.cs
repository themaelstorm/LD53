using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [SerializeField] protected GameManager _gameManager;

    public virtual void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
}
