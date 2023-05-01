
using UnityEngine;

public class DeliveryZone : CustomAgent
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameManager.Events.DeliverBaby(transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn") //babypod
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
