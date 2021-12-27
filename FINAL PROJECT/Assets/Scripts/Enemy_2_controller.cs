using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2_controller : MonoBehaviour
{
    public Animator g_enemy_2_animator;
    public GameObject g_enemy_2;
    public Rigidbody2D g_enemy_2_rb;

    float g_enemy_2_moveSpeed = 0;

    bool g_enemy_goingLeft;

    float g_platform_left_boundsX = 0f;
    float g_platform_right_boundsX = 0f;

    private Vector3 g_enemy_inital_pos = Vector3.zero;

    public AudioClip g_enemy_attack_soundClip;
    public AudioSource g_audioSource;


    // Start is called before the first frame update
    void Start()
    {
        g_enemy_goingLeft = true;
        g_enemy_2_moveSpeed = 0.0075f;

        g_platform_left_boundsX = -4f;
        g_platform_right_boundsX = 4f;

        g_enemy_inital_pos = this.transform.position;

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
        m_enemy_movement();
        m_game_bounds();
    }

    void m_enemy_movement()
    {
        //float l_pos_y = this.transform.position.y;
        g_audioSource.clip = g_enemy_attack_soundClip;
        
        g_audioSource.Play();
        

        this.transform.Translate(Vector2.left * g_enemy_2_moveSpeed );
        //print(this.transform.localPosition.x+" "+this.transform.position.x);
        if (this.transform.localPosition.x < g_platform_left_boundsX && g_enemy_goingLeft)
        {
            this.transform.Rotate(Vector2.up, 180f);
            g_enemy_goingLeft = !g_enemy_goingLeft;
        }
        if (this.transform.localPosition.x > g_platform_right_boundsX && !g_enemy_goingLeft)
        {
            this.transform.Rotate(Vector2.up, 180f);
            g_enemy_goingLeft = !g_enemy_goingLeft;
        }

        
    }

    void m_game_bounds()
    {
        if(this.transform.position.y < -10f)
        {
            m_reset_enemy_pos();
            //this.transform.gameObject.SetActive(false);     
        }
    }

    public void m_reset_enemy_pos()
    {
        this.transform.position = g_enemy_inital_pos;
    }
}
