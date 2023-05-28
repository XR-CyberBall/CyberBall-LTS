using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
  
    public enum PrefKeys
    {
        ITERATION
    }
    
    public enum Scenes_ID
    {

        PANEL_SCENE,
        GameScene
        
    }

    public enum Navs_Lanels
    {
        /// <summary>
        /// This enum created to give an Specific to each  Button of the nav Bar 
        /// </summary>
        NAV_CALIBRATION,
        NAV_GLOVES_SETTINGS,
        NAV_PLAYER_SETTINGS,
        GAME_SETTINGS,
        SAVE_PREFRENCE,
        START_GAME,
        RESET_PREFERECES

    }


    public enum Fingers
    {

        FINGER1,
        FINGER2,
        FINGER3,
        FINGER4,
        FINGER5
    }
}
