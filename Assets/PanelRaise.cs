using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRaise : MonoBehaviour
{

    public GameObject _menuPannel;
    public delegate void PanelActivated();

    public static event PanelActivated OnPanelActivated;

    void OnEnable()
    {
        // Raise the event when the panel is fully activated
        if (OnPanelActivated != null)
        {
            OnPanelActivated();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Hide_panel() {

        _menuPannel.SetActive(false); 
    
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
