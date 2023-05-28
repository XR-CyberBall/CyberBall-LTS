using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Assets._scripts.Entities;
using UnityEngine.SceneManagement;
using static ModelsPreferences.M_Gloves;

public enum Menu_Animation
    {
        PLAYER_COLLIDE_WITH_THE_WELL
    }
 

   

    public class MenuManager : MonoBehaviour
    {
    // Start is called before the first frame update


    public Navigated_Pannel[] _list_Panels;
    public GameObject _menuPanel;
    public C_Feedback Feedback_fbb;
    public C_Feedback Feedback_vib;

    /// <summary>
    /// Gamge setting that is responsible on saving the preferences 
    /// </summary>
    public C_GameSettings Settings ;

   
    
    private static GameObject[] _Naviagtor;

    public static MenuManager Instance { get; private set; }

        
        private Animator animator;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        void Start()
        {
            try
            {

                if (_menuPanel == null)
                {
                    throw new UnityException("The panel is not defined");

                }
            animator = _menuPanel.GetComponent<Animator>();

            _menuPanel.SetActive(false);
         

            }

            catch (UnityException ex)
            {
                Debug.Log(ex.Message);

            }
        Load_MenuManager_Settings();



        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Show_Hide_MenuPanel(bool show = false)
        {
            _menuPanel.SetActive(show);

        }

    public void Start_Showing_Animation(bool Stop_animation = false)
    {
        animator.SetBool("Hide", false);

    }
    public void Stop_showing_Animation()
    {
        animator.SetBool("Hide", true);
       
    }

    /// <summary>
    /// Load the  view with saved preferences 
    /// </summary>
    public void Load_MenuManager_Settings()
    {
     
        Settings.Set_Settings_view();
        Feedback_fbb.LoadSliderValues_View(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK);
        Feedback_vib.LoadSliderValues_View(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK);
        Debug.Log("Settings are updated");

    }

    /// <summary>
    /// Save the panel settings  
    /// </summary>
    public void Save_Nenu_Manager_Setting()
    {
        Settings.Update_Settings();
        Feedback_fbb.SaveSliderValues(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK);
        Feedback_vib.SaveSliderValues(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK);

    }

    /// <summary>
    /// Desactivate the panel
    /// </summary>
    /// <param name="label"> The Label is ID assdigned to each panel</param>
    public void DesactivatePanels(Enums.Navs_Lanels label)
    {

        foreach (Navigated_Pannel panel in _list_Panels)
        {
            if (panel.ID == label)
            {
                panel.Desactivate(false);

            }
            else
            {
                panel.Desactivate();

            }
            

        }
    }
    


    private void OnDestroy()
    {
        Debug.Log("debug from 152 menu manager");
        Save_Nenu_Manager_Setting();


    }

 

    public void Change_The_Scene(Enums.Scenes_ID Scene_ID)
    {
        
        SceneManager.LoadScene(Scene_ID.ToString());

    }
      public void stop_Vib()
    {

        Feedback_vib.stop_feedback(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK);

    }

    public void test_Vib()
    {
        Feedback_vib.test_FeedBack(GLOVES_FEEDBACK_PREF.VIBRATION_FEEDBACK);

    }

  public void test_fbb()
    {
        Feedback_fbb.test_FeedBack(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK);
    }
    public void stop_fbb()
    {

        Feedback_fbb.stop_feedback(GLOVES_FEEDBACK_PREF.FBB_FEEDBACK);

    }
}


