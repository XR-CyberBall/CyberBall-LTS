using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ModelsPreferences;
using static ModelsPreferences.M_Gloves;
using E_Settings;
public class C_Feedback : MonoBehaviour
{
    public SlideFeedback[] sliders;
    private M_Gloves mGloves= new M_Gloves();
    public C_Gloves_configuration config_Gloves;
    public void SaveSliderValues(GLOVES_FEEDBACK_PREF pref)
    {
        mGloves.SaveSliderValues(sliders, pref);
    }


    public void LoadSliderValues_View(GLOVES_FEEDBACK_PREF pref)
    {
        Dictionary<string, float> sliderValuesDict = mGloves.GetSlidersvalue(pref);
  

        if (sliderValuesDict!=null)
        {
            // Retrieve the JSON string from PlayerPrefs
            

            // Iterate through the SlideFeedback objects and set their values based on the saved dictionary
            foreach (SlideFeedback slideFeedback in sliders)
            {
                string fingerID = slideFeedback.Finger_ID.ToString();
                float sliderValue;
                if (sliderValuesDict.TryGetValue(fingerID, out sliderValue))
                {
                    slideFeedback.slider.value = sliderValue;
                    slideFeedback.UpdateTextValue(sliderValue);
                }
            }
        }

    }

    public void test_FeedBack(GLOVES_FEEDBACK_PREF pref)
    {
        Dictionary<SGCore.Finger, float> sliderValuesDict = new Dictionary<SGCore.Finger, float>();
        Debug.Log("pref nme 47"+pref.ToString());
      foreach (SlideFeedback sliderValue in sliders)
        {
            sliderValuesDict.Add(sliderValue.Finger_ID, sliderValue.slider.value);
        }

        config_Gloves.SlidersValues = sliderValuesDict;

        if (pref.Equals(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK))
        {
            config_Gloves.testFbb = true;

        }

         if (pref.Equals(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK))
        {

            config_Gloves.testVib = true;
        }
    }
    public void stop_feedback(GLOVES_FEEDBACK_PREF feedback)
    {

        if (feedback.Equals(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK))
        {
            config_Gloves.Stop_Vib();


        }
        if (feedback.Equals(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK))
        {

            config_Gloves.Stop_fbb();
        }
    }


}