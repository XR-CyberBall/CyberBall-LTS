using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Player_Char : MonoBehaviour
{
    public E_Player_Chara playerChara;

    public void Start()
    {
        genderDropdown.onValueChanged.AddListener(delegate { AssignValues(); });
        skinDropdown.onValueChanged.AddListener(delegate { AssignValues(); });
        raceDropdown.onValueChanged.AddListener(delegate { AssignValues(); });
    }

    // Reference to the dropdown UI element
    public Dropdown genderDropdown;
    public Dropdown skinDropdown;
    public Dropdown raceDropdown;

    // Assign selected values to the playerChara object
    public void AssignValues()
    {
        Gender selectedGender = (Gender)genderDropdown.value;
        Skin selectedSkin = (Skin)skinDropdown.value;
        Race selectedRace = (Race)raceDropdown.value;

        playerChara.UserGender = selectedGender;
        playerChara.UserSkin = selectedSkin;
        playerChara.UserRace = selectedRace;
    }

}
