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

     private void OnCollisionEnter2D(Collision2D l_Collision)
    {

        //print("HELLO");
        if (l_Collision.transform.tag == "Platform")
        {
            m_animation_controller(0); 
        }
       
    }

    private void OnTriggerEnter2D(Collider2D l_Collision)
    {

        if (l_Collision.transform.tag == "Coin")
        {
            l_Collision.gameObject.SetActive(false);

            g_audioSource_1.clip = g_coin_collected;
            g_audioSource_1.Play();
            g_score_manager_instance.m_change_Score(1);
            //SCORE
        }

        if(l_Collision.transform.tag == "Enemy")
        {
            g_bg_movement_sc_ref.GetComponent<BG_movement_manager>().g_scroll_speed = 0f;
            print("there");
        }
    }

    private void m_player_control_manager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
        g_player_jump_Velocity = 9f;

        this.transform.position = new Vector2(-9, -6f);
        //g_player_rB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_player_fall_dies();
        m_player_control_manager();
    }
}
