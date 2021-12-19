using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3_controller : MonoBehaviour
{
    public Animator g_enemy_3_animator;

    public GameObject g_enemy_3;

    public Rigidbody2D g_enemy_3_rb;
    private float g_enemy_jump_Velocity = 0;

    private Vector3 g_enemy_inital_pos = Vector3.zero;

    public AudioClip g_enemy_attack_soundClip;
    public AudioSource g_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        g_enemy_jump_Velocity = 6f;
        g_enemy_inital_pos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        m_game_bounds();
    }

    void OnCollisionEnter2D(Collision2D l_collision)
    {
        if (l_collision.transform.tag == "Platform")
        {
            g_enemy_3_rb.velocity = new Vector2(-1,1) * g_enemy_jump_Velocity;

            g_audioSource.clip = g_enemy_attack_soundClip;
            g_audioSource.Play();
        }
    }

    void m_game_bounds()
    {
        if (this.transform.position.x < -12f || this.transform.position.y < -12f)
        {
            m_reset_enemy_pos();
            this.transform.gameObject.SetActive(false);
        }
    }

    public void m_reset_enemy_pos()
    {
        this.transform.localPosition = g_enemy_inital_pos;

    }
}
