using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : CustomBehaviour
{
    public List<CustomAgent> Agents;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        foreach (var agent in Agents)
        {
            agent.Init(_gameManager);
        }


    }

    public void Pause()
    {
        foreach (var agent in Agents)
        {
            agent.Pause();
        }
    }

    public void Resume()
    {

        foreach (var agent in Agents)
        {
            agent.Resume();
        }
    }
}
