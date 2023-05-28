using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using E_Settings;
namespace ModelsPreferences { 
public class M_Gloves 

{
        public enum GLOVES_FEEDBACK_PREF{

            VIBRATION_FEEDBACK,
            FBB_FEEDBACK


        }



    public void SaveSliderValues(SlideFeedback[] sliders, GLOVES_FEEDBACK_PREF pref_name )
    {
        List<SliderValue> sliderValuesList = new List<SliderValue>();

        // Iterate through the SlideFeedback objects and save their values
        foreach (SlideFeedback slideFeedback in sliders)
        {
            string fingerID = slideFeedback.Finger_ID.ToString();
            float sliderValue = slideFeedback.slider.value;
            Debug.Log(fingerID + ": " + sliderValue);

            SliderValue sliderValueObj = new SliderValue();
            sliderValueObj.fingerID = fingerID;
            sliderValueObj.sliderValue = sliderValue;

            sliderValuesList.Add(sliderValueObj);
        }

        SliderValuesWrapper sliderValuesWrapper = new SliderValuesWrapper();
        sliderValuesWrapper.sliderValuesList = sliderValuesList;

        // Convert the wrapper class to a JSON string
        string jsonString = JsonUtility.ToJson(sliderValuesWrapper);
        Debug.Log("Serialized JSON: " + jsonString);
        // Save the JSON string to PlayerPrefs
        PlayerPrefs.SetString(pref_name.ToString(), jsonString);

        // Save PlayerPrefs to disk
        PlayerPrefs.Save();
    }


    public Dictionary<string,float> GetSlidersvalue(GLOVES_FEEDBACK_PREF pref)
    {
        // Check if there are saved slider values in PlayerPrefs
        if (PlayerPrefs.HasKey(pref.ToString()))
        {
                Debug.Log(" loaded Pref Name : " + pref.ToString());

                // Retrieve the JSON string from PlayerPrefs
                string jsonString = PlayerPrefs.GetString(pref.ToString());

            // Deserialize the JSON string into the wrapper class
            SliderValuesWrapper sliderValuesWrapper = JsonUtility.FromJson<SliderValuesWrapper>(jsonString);

            // Retrieve the dictionary from the wrapper class
            Dictionary<string, float> sliderValuesDict = new Dictionary<string, float>();
            foreach (SliderValue sliderValue in sliderValuesWrapper.sliderValuesList)
            {
                sliderValuesDict.Add(sliderValue.fingerID, sliderValue.sliderValue);
            }


            return sliderValuesDict;
        }
        return null;

    }


}
}