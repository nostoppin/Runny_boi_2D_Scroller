using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_player_controller : MonoBehaviour
{
    public Animator g_player_animator;

    public GameObject g_player;
    
    public GameObject g_Game_over_handler_object;

    public Rigidbody2D g_player_rB;

    public AudioClip g_playerJump_sound_clip;
    public AudioClip g_coin_collected;
    public AudioSource g_audioSource;
    public AudioSource g_audioSource_1;

    float g_player_jump_Velocity = 0f;

    public  Score_manager g_score_manager_instance;

    public BG_movement_manager g_bg_movement_sc_ref;
    int g_jump_count = 0;
    bool g_isJumping;

    public void m_animation_controller(int l_player_anim_state)
    {
        g_player_animator.SetBool("Run", false);
        g_player_animator.SetBool("Jump", false);
        if (l_player_anim_state == 0)
        {
            g_player_animator.SetBool("Run", true);
        }
        if(l_player_anim_state == 1)
        {
            g_player_animator.SetBool("Jump", true);
        }
    }

     void OnCollisionEnter2D(Collision2D l_Collision)
    {

        //print("HELLO");
        if (l_Collision.transform.tag == "Platform")
        {
            m_animation_controller(0);
            g_isJumping = false;
        }

        if (l_Collision.transform.tag == "Enemy")
        {
            Time.timeScale = 0f;
            
            g_Game_over_handler_object.GetComponent<Game_over_handler>().m_to_game_over_Screen();
            
        }
    }


    void OnTriggerEnter2D(Collider2D l_Collision)
    {

        if (l_Collision.transform.tag == "Coin")
        {
            l_Collision.gameObject.SetActive(false);

            g_audioSource_1.clip = g_coin_collected;
            g_audioSource_1.Play();
            g_score_manager_instance.m_change_Score(1);
            //SCORE
        }
    }

    private void m_player_control_manager()
    {
        //jump
        if (g_isJumping == true && Input.GetMouseButtonDown(0))
        {
            g_player_rB.velocity = Vector2.up * g_player_jump_Velocity;
            g_isJumping = false;
        }
        if (Input.GetMouseButtonDown(0) && g_player_rB.velocity.y == 0)
        {
            g_isJumping = true;
            g_jump_count += 1;
            m_animation_controller(1);
            g_audioSource.clip = g_playerJump_sound_clip;
            g_audioSource.Play();
            g_player_rB.velocity = Vector2.up * g_player_jump_Velocity;
        }

         
    }

    public void m_player_fall_dies()
    {
        if(this.transform.position.y < -8.5f )
        {
            g_Game_over_handler_object.GetComponent<Game_over_handler>().m_to_game_over_Screen();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        g_isJumping = false;
        g_player_jump_Velocity = 7f;
       
        this.transform.position = new Vector2(-9, -6f);

        if(PlayerPrefs.GetInt("Audio") == 0)
        {
            g_audioSource.volume = 0;
            g_audioSource_1.volume = 0;
        }
        else
        {
            g_audioSource.volume = 1;
            g_audioSource_1.volume = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(this.GetComponent<Rigidbody2D>().velocity.y);
        m_player_fall_dies();
        m_player_control_manager();
    }
}
