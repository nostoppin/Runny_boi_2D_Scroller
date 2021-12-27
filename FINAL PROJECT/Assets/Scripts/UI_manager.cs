using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public GameObject g_menu_screenHolder;
    public GameObject g_rules_screenHolder;

    public AudioSource g_menu_audio_Source;
    public AudioClip g_background_menu_music;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        g_menu_audio_Source.clip = g_background_menu_music;
        g_menu_audio_Source.Play();
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            this.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            this.GetComponent<AudioSource>().volume = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void m_start_game()
    {
        print("here");
        
        SceneManager.LoadScene("Game_scene_one");
        Time.timeScale = 1f;
        g_menu_audio_Source.Stop();
    }

    public void m_switchTo_RulesScreen()
    {
        g_menu_screenHolder.SetActive(false);
        g_rules_screenHolder.SetActive(true);
    }

    public void m_switchTo_MainMenuScreen()
    {
        g_menu_screenHolder.SetActive(true);
        g_rules_screenHolder.SetActive(false);
    }

    public void m_OnValueChange(Toggle l_Tog)
    {
        
        //PlayerPrefs.SetInt("Game Sounds", 0);
        if(l_Tog.isOn == true)
        {
            g_menu_audio_Source.volume = 1;
            PlayerPrefs.SetInt("Audio", 1);
        }
        if(l_Tog.isOn == false)
        {
            g_menu_audio_Source.volume = 0;
            PlayerPrefs.SetInt("Audio", 0);
        }   
    }

    public void m_onExit()
    {
        //print("here");
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
