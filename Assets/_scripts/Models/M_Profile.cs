using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class M_Profile
{

    [System.Serializable]
    public class Profiles
    {


        public SerializableDictionary<string, User_Profile> List_of_profile = new SerializableDictionary<string, User_Profile>();

    }

    public Profiles List_of_current_profiles(User_Profile profile)
    {

        if (PlayerPrefs.HasKey("profiles"))
        {

            string Profiles = PlayerPrefs.GetString("profiles");

            Profiles profile_class = JsonUtility.FromJson<Profiles>(Profiles);

            if (profile_class.List_of_profile.ContainsKey(profile.UUID))
            {
                profile_class.List_of_profile[profile.UUID] = profile;

            }
            else
            {
                profile_class.List_of_profile.Add(profile.UUID, profile);


            }
            return profile_class;




        }
        else
        {
            Profiles List_of_profiles = new Profiles();


            List_of_profiles.List_of_profile.Add(profile.UUID, profile);

            return List_of_profiles;
        }



    }


    public bool Save_profile(User_Profile profile)
    {
        Profiles current_profiles = List_of_current_profiles(profile);

        string List_of_profiles = JsonUtility.ToJson(current_profiles);
        Debug.Log("profile: " + List_of_profiles);

        PlayerPrefs.SetString("profiles", List_of_profiles);




        return true;

    }

    public Profiles Load_profile()
    {

        if (PlayerPrefs.HasKey("profiles"))
        {

            string Profiles = PlayerPrefs.GetString("profiles");

            Console.WriteLine("profiles", Profiles);

            Profiles List_of_profiles = JsonUtility.FromJson<Profiles>(Profiles);



            return List_of_profiles;




        }
        else return null;
    }

    public User_Profile Get_profile_By_id(string id)
    {

        Profiles profiles = Load_profile();

        return profiles.List_of_profile[id];





    }

}
