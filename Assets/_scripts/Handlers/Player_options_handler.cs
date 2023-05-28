using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_options_handler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Gender selectedGender;


    public Race selectedRace;
    public Skin selectedSkin;

    public void OnRaceDropdownValueChanged(Dropdown dropdown)
    {
        selectedRace = (Race)dropdown.value;
        Debug.Log("Selected Race: " + selectedRace);
    }

    public void OnSkinDropdownValueChanged(Dropdown dropdown)
    {
        selectedSkin = (Skin)dropdown.value;
        Debug.Log("Selected Skin: " + selectedSkin);
    }


    public void OnGenderDropdownValueChanged(Dropdown dropdown)
    {
        selectedGender = (Gender)dropdown.value;
        Debug.Log("Selected Gender: " + selectedGender);
    }

    public E_Player_Chara GetPlayerChara(string name)
    {
        return new E_Player_Chara(name, selectedGender, selectedSkin, selectedRace);
    }
}
