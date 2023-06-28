using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Notification_Game_Manager : MonoBehaviour
{
    public C_Notification_Panel Counter_panel;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Start_Notification_counter(int seconds)
    {

        Counter_panel.active(true);
        Counter_panel.StartCounter(seconds);

    }
   public void update_Notification_counter_message(string message) {

        Counter_panel.set_notification_message(message);


    }


}
