using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlideFeedback : MonoBehaviour
{
    public SGCore.Finger Finger_ID;
    public Slider slider;
    public TMP_Text value;

    void Start()
    {
        // Add a listener to the slider's OnValueChanged event
        slider.onValueChanged.AddListener(UpdateTextValue);
        
    }

  public  void UpdateTextValue(float value)
    {
        // Convert the value to a string with two decimal places and append the "%" symbol
        string formattedValue = value.ToString("0.00") + "%";

        // Update the TMP_Text component's text with the formatted value
        this.value.text = formattedValue;
    }

   
}
