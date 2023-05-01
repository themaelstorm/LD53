using System.Collections.Generic;
using UnityEngine;

public class Level : CustomBehaviour
{
    public List<CustomAgent> Agents;
    public int BabyDeliveryCount;
    public int DeliveryMade;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        foreach (var agent in Agents)
        {
            agent.Init(_gameManager);
        }

        _gameManager.Events.OnBabyDelivered += BabyDelivered;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnBabyDelivered -= BabyDelivered;
    }

    private void BabyDelivered(Vector3 t)
    {
        DeliveryMade++;
        _gameManager.Events.UpdatePlayerStats();

        if (DeliveryMade == BabyDeliveryCount)
            _gameManager.Events.CompleteLevel();
    }
}
