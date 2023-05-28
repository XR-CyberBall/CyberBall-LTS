using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveTelepor : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject leftTelportaion; 
    public GameObject rightTelportaion;
    public InputActionProperty lefActivate;
    public InputActionProperty rightActivate;
    public InputActionProperty lefcancel;
    public InputActionProperty rightCancel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftTelportaion.SetActive(lefcancel.action.ReadValue<float>() ==0 && lefActivate.action.ReadValue<float>() > 0.1f);

      
    }
}
