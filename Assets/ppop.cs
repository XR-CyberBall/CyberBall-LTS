using E_Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ppop : MonoBehaviour
{
    // Start is called before the first frame update
    User_Profile userProfile;
    void Start()
    {
        create_Fake_user();
    }
    void create_Fake_user()
    {

         userProfile = new User_Profile();

        // Add players
        List<E_Player_Chara> players = new List<E_Player_Chara>()
{
    new E_Player_Chara("Player 1", Gender.Male, Skin.Light, Race.African),
    new E_Player_Chara("Player 2", Gender.Female, Skin.Medium, Race.Other)
};
        userProfile.SetPlayers(players);

        // Add slider values for FBB (example)
        SliderValuesWrapper fbbSliderValues = new SliderValuesWrapper();

     
        userProfile.SetSliderValuesWrapper_FBB(fbbSliderValues);

        // Add slider values for VIB (example)
        SliderValuesWrapper vibSliderValues = new SliderValuesWrapper();
  
        userProfile.SetSliderValuesWrapper_VIB(vibSliderValues);



    }
    // Update is called once per frame
    void Update()
    {
    }
}
