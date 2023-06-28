using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyers_Status : MonoBehaviour
{
    public Enums.PLAYER_INDEX playerindex;
    public Transform player_Transform;
    public C_VFX_Controller Circle_controler;
    public Transform targetHand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Waiting_circle_ball(Color startcolor,Color endcolor)
    {

        Circle_controler.Waiting_Status(startcolor, endcolor);


    }
    
    public void Reset_circle_ball()
    {
        Circle_controler.Reset_status();

    }
}
