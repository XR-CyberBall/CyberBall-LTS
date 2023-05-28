using E_Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class User_Profile
{

    public List<E_Player_Chara> Players;
    public bool tes;
    public SliderValuesWrapper sliderValuesWrapper_FBB;
    public SliderValuesWrapper sliderValuesWrapper_VIB;

    // Default constructor
    public User_Profile()
    {
        Players = new List<E_Player_Chara>();
        sliderValuesWrapper_FBB = new SliderValuesWrapper();
        sliderValuesWrapper_VIB = new SliderValuesWrapper();
    }

    // Setter for Players
    public void SetPlayers(List<E_Player_Chara> players)
    {
        Players = players;
    }

    // Getter for Players
    public List<E_Player_Chara> GetPlayers()
    {
        return Players;
    }

    // Setter for sliderValuesWrapper_FBB
    public void SetSliderValuesWrapper_FBB(SliderValuesWrapper valuesWrapper)
    {
        sliderValuesWrapper_FBB = valuesWrapper;
    }

    // Getter for sliderValuesWrapper_FBB
    public SliderValuesWrapper GetSliderValuesWrapper_FBB()
    {
        return sliderValuesWrapper_FBB;
    }

    // Setter for sliderValuesWrapper_VIB
    public void SetSliderValuesWrapper_VIB(SliderValuesWrapper valuesWrapper)
    {
        sliderValuesWrapper_VIB = valuesWrapper;
    }

    // Getter for sliderValuesWrapper_VIB
    public SliderValuesWrapper GetSliderValuesWrapper_VIB()
    {
        return sliderValuesWrapper_VIB;
    }
}
