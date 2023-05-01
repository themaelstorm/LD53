using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    public EventManager Events;
    public LevelManager Levels;

    public StorkController Stork;



    // Start is called before the first frame update
    void Start()
    {
        Events.Init(this);
        UI.Init(this);
        Levels.Init(this);
        Stork.Init(this);

        Events.StartGame();

    }

    public void PauseGame()
    {
        Stork.Pause();
        Levels.Pause();
    }

    public void ResumeGame()
    {
        Stork.Resume();
        Levels.Resume();
    }

}
