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
    public SliderValuesWrapper Get_Slider_Wraper()
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
        return sliderValuesWrapper;
    }

    public void LoadSliderValues_View(GLOVES_FEEDBACK_PREF pref,User_Profile user=null)
    {
        Dictionary<string, float> sliderValuesDict ;

        if (user != null)
        {
            sliderValuesDict = new Dictionary<string, float>();

            if (pref.Equals(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK))
            {

                foreach (SliderValue sliderValue in user.sliderValuesWrapper_FBB.sliderValuesList)
                {
                    sliderValuesDict.Add(sliderValue.fingerID, sliderValue.sliderValue);
                }
            }
            else if(pref.Equals(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK))  {

                foreach (SliderValue sliderValue in user.sliderValuesWrapper_VIB.sliderValuesList)
                {
                    sliderValuesDict.Add(sliderValue.fingerID, sliderValue.sliderValue);
                }
            }
              

        }
        else
        {
            sliderValuesDict = mGloves.GetSlidersvalue(pref);
        }

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