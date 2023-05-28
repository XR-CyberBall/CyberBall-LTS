using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Gender
{
    Male,
    Female,
    Other
}

public enum Skin
{
    Light,
    Medium,
    Dark
}

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


    public string Name { get; set; }
    public Gender UserGender { get; set; }
    public Skin UserSkin { get; set; }
    public Race UserRace { get; set; }

    // Constructor
    public E_Player_Chara(string name, Gender gender, Skin skin, Race race)
    {
        Name = name;
        UserGender = gender;
        UserSkin = skin;
        UserRace = race;
    }

}
