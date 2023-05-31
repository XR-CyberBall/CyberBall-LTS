using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using E_Settings;

public class C_GameSettings : MonoBehaviour
{

    public C_Feedback Fbb;
    public C_Feedback Vib;
    public List<Player_options_handler> players;
    public User_Profile User ;
    M_Profile Model_Profile = new M_Profile();

    public C_GameSettings addPlayer()
    {
        foreach (Player_options_handler player in players)
        {
            User.Players.Add(player.GetPlayerChara("jhon"));
        }
        return this;



    }

    public C_GameSettings addFbb() {

        User.sliderValuesWrapper_FBB = Fbb.Get_Slider_Wraper();
        User.sliderValuesWrapper_VIB = Vib.Get_Slider_Wraper();
        return this;
    }


    public void loadProfile_FBB(User_Profile user)
    {


        foreach (SlideFeedback slider in Fbb.sliders)
        {
            foreach (SliderValue slidervalue in user.sliderValuesWrapper_FBB.sliderValuesList)
            {


                if (slider.Finger_ID.ToString() == slidervalue.fingerID)
                {

                    slider.UpdateTextValue(slidervalue.sliderValue);
                }
            }
        }

        foreach (SlideFeedback slider in Vib.sliders)
        {
            foreach (SliderValue slidervalue in user.sliderValuesWrapper_VIB.sliderValuesList)
            {


                if (slider.Finger_ID.ToString() == slidervalue.fingerID)
                {

                    slider.UpdateTextValue(slidervalue.sliderValue);
                }
            }
        }
    }
    public void save_profile(User_Profile profile)
    {
        Model_Profile.Save_profile(profile);


    }

    public M_Profile.Profiles Get_profiles()
    {


        M_Profile.Profiles profiles = Model_Profile.Load_profile();
        return profiles;

    }

   




    /// <summary>
    /// This  Setting controller will take the data from  the inputs fileds of the setting  and save them in the preferences
    /// 
    /// </summary>

    [Tooltip("This is the input of the Game iteration")]

    public TMP_InputField _GameIteration;
    [Tooltip("This is the Drop Down menu of the Game iteration")]





    public TMP_Dropdown _Dropdown__GameIteration;
    /// <summary>
    /// Up update the preferences 
    /// </summary>
    public void Update_Settings()
    {

        TMP_Dropdown.OptionData Selected_option = _Dropdown__GameIteration.options[_Dropdown__GameIteration.value];

        int Selected_Iteration = _Dropdown__GameIteration.value;

        PlayerPrefs.SetInt(Enums.PrefKeys.ITERATION.ToString(), Selected_Iteration);
   

    }
    /// <summary>
    ///  Extract the preferneces from the input files 
    /// </summary>
    /// <returns></returns>
  
    public Game_Settings Get_Settings() 
    {

        int Irretation = PlayerPrefs.GetInt(Enums.PrefKeys.ITERATION.ToString(),0);

        Game_Settings Est = new Game_Settings();
        Est.Irretation = Irretation;
        return Est;

    }


       
    /// <summary>
    /// Update the View of the panel
    /// </summary>
    public void Set_Settings_view()

    {

        _Dropdown__GameIteration.value = Get_Settings().Irretation;
    }
  

}
