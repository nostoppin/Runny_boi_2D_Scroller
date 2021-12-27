using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_over_handler : MonoBehaviour
{
    public GameObject g_game_over_screenHolder;
    
    public Text g_high_score_text;
    public Text g_no_high_score_text;

    public GameObject Score_manager;

    int g_current_score = 0;

    void Start()
    {
        print(PlayerPrefs.GetInt("HighScore"));
    }

    
    public void m_to_game_over_Screen()
    {
        Time.timeScale = 0f;
        g_game_over_screenHolder.SetActive(true);
    }

    public void m_toMain_menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }

    public void m_set_highScore()
    {
        g_current_score = Score_manager.GetComponent<Score_manager>().g_current_score;
        //print(g_current_score);
        if (g_current_score > PlayerPrefs.GetInt("HighScore"))
        {
            
            PlayerPrefs.SetInt("HighScore", g_current_score);
            g_no_high_score_text.text = "Congratulations!";
            g_high_score_text.text = g_current_score.ToString();
        }
        else
        {
            g_high_score_text.text = g_current_score.ToString();
            g_no_high_score_text.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
        }
        
    }
    private void Update()
    {
        //print(g_current_score);
        m_set_highScore();
    }
}
