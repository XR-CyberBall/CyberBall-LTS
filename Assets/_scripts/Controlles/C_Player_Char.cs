using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Player_Char : MonoBehaviour
{
    public E_Player_Chara playerChara;
    public Player_options_handler Player_options;

    // Assign selected values to the playerChara object
    public void AssignValues()
    {
        

        playerChara.UserGender = Player_options.selectedGender;
        playerChara.UserSkin = Player_options.selectedSkin;
        playerChara.UserRace = Player_options.selectedRace;
    }

}
