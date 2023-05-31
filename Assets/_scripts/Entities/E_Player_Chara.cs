using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Gender
{
    Male,
    Female,
    Other
}
[System.Serializable]
public enum Skin
{
    Light,
    Medium,
    Dark
}
[System.Serializable]
public enum Race
{
    Caucasian,
    African,
    Asian,
    Hispanic,
    Other
}

[System.Serializable]
public class E_Player_Chara
{
    public string Name;
    public Gender UserGender;
    public Skin UserSkin;
    public Race UserRace;

    // Constructor
    public E_Player_Chara(string name, Gender gender, Skin skin, Race race)
    {
        Name = name;
        UserGender = gender;
        UserSkin = skin;
        UserRace = race;
    }

}
