using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class C_Profile_loader : MonoBehaviour
{
    public TMP_Dropdown _dropdown;
    protected string _valueText;
    public Button _load_user;
    public Button _create_user;

    public MenuManager menuManager;
    void Start()
    {
        _dropdown.ClearOptions();
        menuManager.Load_profiles();
        Show_profile_ids();
        _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        _load_user.onClick.AddListener(Button_Load_Profile);
        _create_user.onClick.AddListener(create_user);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void create_user()
    {


        menuManager.Create_new_user();
        _dropdown.ClearOptions();

         Show_profile_ids();
    }
    private void Show_profile_ids()
    {
       
        if (menuManager.profiles != null)
        {
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

            foreach (string userID in menuManager.profiles.List_of_profile.Keys)
            {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(userID);
               
                Debug.Log(userID+"ids");
                options.Add(option);


            }
            _dropdown.AddOptions(options);
        }
  
    }

    private void OnDropdownValueChanged(int index)
    {
        string selectedOption = _dropdown.options[index].text;
        _valueText = selectedOption;


    }
    public void Button_Load_Profile()
    {
        Debug.Log("");

        menuManager.load_user(this._valueText);
    }
}
