using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class M_Profile
{

    [System.Serializable]
  public  class Profiles
    {


     public Dictionary<string,User_Setting> List_of_profile;

    }
    private string Generate_UUID()
    {

        Guid uuid = Guid.NewGuid();
        string uuidString = uuid.ToString();
        return uuidString;


    }
    public Profiles List_of_current_profiles(User_Setting profile)
    {

        if (PlayerPrefs.HasKey("profiles")) {

           string Profiles= PlayerPrefs.GetString("profiles");

            Profiles List_of_profiles = JsonUtility.FromJson<Profiles>(Profiles);

            List_of_profiles.List_of_profile.Add(Generate_UUID(), profile);

            return List_of_profiles;




        }
        else
        {

            Profiles List_of_profiles = new Profiles();

            List_of_profiles.List_of_profile.Add(Generate_UUID(), profile);

            return List_of_profiles;
        }



    }


    public bool Save_all_profiles(User_Setting profile)
    {
              Profiles current_profiles= List_of_current_profiles(profile);
              string profiles= PlayerPrefs.GetString("profiles");


                PlayerPrefs.SetString("profiles", profiles);
                        



        return true ;
     
}
    
    public Profiles Load_profile() {

        if (PlayerPrefs.HasKey("profiles"))
        {

            string Profiles = PlayerPrefs.GetString("profiles");

            Profiles List_of_profiles = JsonUtility.FromJson<Profiles>(Profiles);



            return List_of_profiles;




        }
        else return null;
    }

    
 
}
