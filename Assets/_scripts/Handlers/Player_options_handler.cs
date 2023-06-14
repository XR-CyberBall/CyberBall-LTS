using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player_options_handler : MonoBehaviour
{

    public TMP_Dropdown genderDropdown;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown skinDropdown;

    public Gender selectedGender;
    public Race selectedRace;
    public Skin selectedSkin;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerChara(E_Player_Chara playerChara)
    {
        selectedGender = playerChara.UserGender;
        selectedSkin = playerChara.UserSkin;
        selectedRace = playerChara.UserRace;

        UpdateUIElements();

        Debug.Log("Loaded Player Character: Name = " + playerChara.Name +
                  ", Gender = " + playerChara.UserGender +
                  ", Skin = " + playerChara.UserSkin +
                  ", Race = " + playerChara.UserRace);
    }
    private void UpdateUIElements()
    {
        genderDropdown.value = (int)selectedGender;
        raceDropdown.value = (int)selectedRace;
        skinDropdown.value = (int)selectedSkin;
    }


    public void OnRaceDropdownValueChanged(TMP_Dropdown dropdown)
    {
        selectedRace = (Race)dropdown.value;
        Debug.Log("Selected Race: " + selectedRace);
    }

    public void OnSkinDropdownValueChanged(TMP_Dropdown dropdown)
    {
        selectedSkin = (Skin)dropdown.value;
        Debug.Log("Selected Skin: " + selectedSkin);
    }


    public void OnGenderDropdownValueChanged(TMP_Dropdown dropdown)
    {
        selectedGender = (Gender)dropdown.value;
        Debug.Log("Selected Gender: " + selectedGender);
    }

    public E_Player_Chara GetPlayerChara(string name)
    {
        return new E_Player_Chara(name, selectedGender, selectedSkin, selectedRace);
    }
}
