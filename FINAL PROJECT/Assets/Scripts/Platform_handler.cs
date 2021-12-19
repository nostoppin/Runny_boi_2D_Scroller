using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_handler : MonoBehaviour
{
    public float g_platform_move_speed = 0f;

    public int g_type = 0;

    public GameObject g_enemy_object;

    public GameObject g_coin_object_1;
    public GameObject g_coin_object_2;
    public GameObject g_coin_object_3;

    private Vector3 g_coin_one_initial_pos = Vector3.zero;
    private Vector3 g_coin_two_initial_pos = Vector3.zero;
    private Vector3 g_coin_three_initial_pos = Vector3.zero;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_game_view_bounds();
        m_platform_movement();
    }

    void m_platform_movement()
    {
        this.transform.Translate(Vector2.left * Time.deltaTime * g_platform_move_speed);
    }

    void m_game_view_bounds()
    {
        if (this.transform.position.x < -45f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        //g_enemy_object.transform
        if(g_coin_object_1 != null)
        {
            g_coin_object_1.SetActive(true);
            g_coin_object_2.SetActive(true);
            g_coin_object_3.SetActive(true);
        }
           

        if (g_enemy_object !=  null)
        {
            g_enemy_object.SetActive(true);
        }
    }
}
