using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloseOpen : MonoBehaviour
{
    public MenuManager MenuPanelManager;
    void Start()
    {
        Debug.Log(" Start hola1");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    Debug.Log("Player is Colided");
                    MenuPanelManager.Show_Hide_MenuPanel(true);
                  
                    MenuPanelManager.Start_Showing_Animation();

                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    Debug.Log("Player out of the collision area");

                    MenuPanelManager.Stop_showing_Animation();
                }
                break;
        }
    }

}
