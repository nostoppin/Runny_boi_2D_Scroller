using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public GameObject g_pause_menu, g_pause_button;

    public void m_to_pause_menu()
    {
        g_pause_menu.SetActive(true);
        g_pause_button.SetActive(false);
        Time.timeScale = 0f; // pause the game completely
    }

    public void m_resume_game()
    {
        g_pause_menu.SetActive(false);
        g_pause_button.SetActive(true);
        Time.timeScale =1f;
    }

    public void m_to_main_menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }
}
