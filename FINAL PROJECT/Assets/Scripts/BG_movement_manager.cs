using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_movement_manager : MonoBehaviour
{
    

    public Transform g_last_element_transform;

    private Vector2 g_sprite_spawnPoint;

    public float g_scroll_speed;

    public int g_move = 0;
    // Start is called before the first frame update
    void Start()
    {
        g_move = 1;
    }

    // Update is called once per frame
    void Update()
    {
         
        m_bg_move_handler();
        m_bg_bounds_evaluator();
    }

    void m_bg_move_handler()
    {
        if(g_move == 1 )
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * g_scroll_speed);
        }
        if(g_move == 0)
        {
            this.transform.Translate(Vector2.zero * Time.deltaTime * g_scroll_speed);
        }
    }

    void m_bg_bounds_evaluator()
    {
        if(this.transform.position.x < -25f)
        {
            g_sprite_spawnPoint = g_last_element_transform.position;
            g_sprite_spawnPoint.x += 18;
            this.gameObject.transform.position = g_sprite_spawnPoint;   
        }
    }
}
