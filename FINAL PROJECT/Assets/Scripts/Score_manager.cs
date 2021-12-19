using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_manager : MonoBehaviour
{
    public static Score_manager g_score_manager;
    public Text g_score_text;
    //public Text g_high_score_text;
    public int g_current_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        g_score_text.text = g_current_score.ToString();

        //g_high_score_text.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void m_change_Score(int l_coin_value)
    {
        g_current_score += l_coin_value;

        g_score_text.text = "x" + g_current_score.ToString();
    }

    
}
