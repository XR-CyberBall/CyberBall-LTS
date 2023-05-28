using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using E_Settings;

public class C_GameSettings:MonoBehaviour
{


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
