using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenByHand : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Button[] Buttons;
    public Button StartButton;
    public Button move_to_next_scene;
    void Start()
    {
        
    }
    public MenuManager menuManager;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {


        }
        if (Input.GetKeyDown(KeyCode.D)) {
             

            dropdown.Show(); ;
        } ;

        if (Input.GetKeyDown(KeyCode.S ) && dropdown.IsExpanded)
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && dropdown.IsExpanded)
        {
            int currentValue = dropdown.value;
            // Increment the value
            currentValue++;
            // Check if we've gone past the end of the options list
            if (currentValue >= dropdown.options.Count)
            {
                // Wrap around to the beginning
                currentValue = 0;
            }
            // Set the new value
            dropdown.value = currentValue;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("button 0 clicked");
            Buttons[0].onClick.Invoke();


        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("button 1 clicked");
            Buttons[1].onClick.Invoke();


        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            menuManager.Load_profiles();
            Debug.Log(menuManager.profiles);
            menuManager.load_user("a9eaf2");
           
            Debug.Log("From line 62");
            StartButton.onClick.Invoke();
        }
    }
}
