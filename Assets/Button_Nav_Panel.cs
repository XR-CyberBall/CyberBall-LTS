using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Nav_Panel :MonoBehaviour
{

    /// <summary>
    /// Desactivate the panel with the button
    /// </summary>
    public MenuManager _Manager;
    
    public Enums.Navs_Lanels _Button_Nav_laebl;


    /// <summary>
    /// The button will use the menu manager to desactivate the panel
    /// </summary>
    public void Desactivate_Panel()
    {

        _Manager.DesactivatePanels(this._Button_Nav_laebl);


    }

    public void Start_The_Game()
    {
        _Manager.Change_The_Scene(Enums.Scenes_ID.GameScene);
    }


}
