using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class M_Profile
{

  [System.Serializable]
  public  class Profiles
    {


     public SerializableDictionary<string,User_Profile> List_of_profile =new SerializableDictionary<string, User_Profile>();

    }
    private string Generate_UUID()
    {

        Guid uuid = Guid.NewGuid();
        string uuidString = uuid.ToString();
        return uuidString;


    }
    public Profiles List_of_current_profiles(User_Profile profile)
    {

        if (PlayerPrefs.HasKey("profiles")) {

           string Profiles= PlayerPrefs.GetString("profiles");

            Profiles profile_class = JsonUtility.FromJson<Profiles>(Profiles);
        
            string uiid = Generate_UUID();
            Debug.Log(uiid);
            profile_class.List_of_profile.Add(uiid, profile);
            string el = "";
            return profile_class;




        }
        else
        {
            Profiles List_of_profiles = new Profiles();


            List_of_profiles.List_of_profile.Add(Generate_UUID(), profile);

            return List_of_profiles;
        }



    }


    public bool Save_profile(User_Profile profile)
    {
              Profiles current_profiles= List_of_current_profiles(profile);

              string List_of_profiles = JsonUtility.ToJson(current_profiles);
              Debug.Log("profile: "+List_of_profiles);
              
               PlayerPrefs.SetString("profiles", List_of_profiles);
                        



               return true ;
     
}
    
    public Profiles Load_profile() {

        if (PlayerPrefs.HasKey("profiles"))
        {

            string Profiles = PlayerPrefs.GetString("profiles");

            Console.WriteLine("profiles", Profiles);

            Profiles List_of_profiles = JsonUtility.FromJson<Profiles>(Profiles);



            return List_of_profiles;




        }
        else return null;
    }

    
 
}
