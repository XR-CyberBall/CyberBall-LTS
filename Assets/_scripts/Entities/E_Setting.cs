using System.Collections;
using System.Collections.Generic;

namespace E_Settings
{




    [System.Serializable]
    public class SliderValuesWrapper
    {
        public SliderValuesWrapper()
        {
            sliderValuesList = new List<SliderValue>();
        }
        public List<SliderValue> sliderValuesList;
    
    }

    [System.Serializable]
    public class SliderValue
    {
        public string fingerID;
        public float sliderValue;
    }
   
    public class Game_Settings
    {
     public   int Irretation;
    }

}
