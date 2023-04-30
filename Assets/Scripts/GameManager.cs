using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    public EventManager Events;


    public StorkController Stork;

    public List<CustomAgent> Agents;

    // Start is called before the first frame update
    void Start()
    {
        Events.Init(this);
        UI.Init(this);

        Stork.Init(this);
        foreach (var agent in Agents)
        {
            agent.Init(this);
        }

        PauseGame();
    }

    public void PauseGame()
    {
        Stork.Pause();
        foreach (var agent in Agents)
        {
            agent.Pause();
        }
    }

    public void ResumeGame()
    {
        Stork.Resume();
        foreach (var agent in Agents)
        {
            agent.Resume();
        }
    }

}
