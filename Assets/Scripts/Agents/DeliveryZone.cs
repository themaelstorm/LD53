using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : CustomBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameManager.Events.DeliverBaby();
        }
    }
}
