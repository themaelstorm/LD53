using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CreditsMenuButton : MonoBehaviour
{
    public GameObject CreditsPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnButtonPress()
    {
        CreditsPanel.SetActive(true);
    }
}
