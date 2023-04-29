using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    public EventManager Events;

    // Start is called before the first frame update
    void Start()
    {
        Events.Init(this);
        UI.Init(this);
    }

}
