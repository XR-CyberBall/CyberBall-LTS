using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RightHandCustomcomponent : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public Animator handAnimator;
    public InputActionProperty gripAnimation;
     
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   
    {

        float gripValue = gripAnimation.action.ReadValue<float>();


        float trigerValue=pinchAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", trigerValue);

        handAnimator.SetFloat("Grip", gripValue);
    }
}
