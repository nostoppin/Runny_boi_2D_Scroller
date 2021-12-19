using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public GameObject g_platform;
    public GameObject g_platform_Enemy_2;
    public GameObject g_platform_Enemy_3;
    public GameObject g_coin;

    GameObject[] g_platform_array;
    //GameObject[] g_coin_array;

    int g_platform_count = 0;
    //int g_coins_count = 0;

    float g_spawnValue_axisX = 0f;
    float g_spawnValue_axisY;

    float g_spawn_interval_elapsed_T = 0;
    float g_spawn_interval_life_T = 0;
    float g_spawn_interval_start_T = 0;

    float g_actual_scene_distance = 0f;

    float g_individual_sprite_size = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        g_platform.GetComponent<Platform_handler>().g_platform_move_speed = 6;
        g_platform_Enemy_2.GetComponent<Platform_handler>().g_platform_move_speed = 6;
        g_platform_Enemy_3.GetComponent<Platform_handler>().g_platform_move_speed = 6;

        //t=d/s
        g_actual_scene_distance = 20f;

        g_spawn_interval_life_T = 1f;
        g_spawn_interval_start_T = Time.time;

        g_spawnValue_axisX = 14f;

        g_platform_count = 15;

        g_platform_array = new GameObject[g_platform_count];

        m_init_all_platforms();

        g_individual_sprite_size = g_platform.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawn_platforms();
        m_increase_Game_Complexity(0.0001f);

        //print(g_platform.GetComponent<Platform_handler>().g_platform_move_speed);
    }

    private void m_spawn_platforms()
    {
        g_actual_scene_distance = 20f;

        //print(l_current_interval);
        g_spawn_interval_elapsed_T = Time.time - g_spawn_interval_start_T;

        if (g_spawn_interval_elapsed_T > g_spawn_interval_life_T)
        {
            float l_spawn_point_choice = m_get_randomValue(1f, 3f); //enable to get random spawn points
            for (int i = 0; i < g_platform_count; i++)
            {
                if (!g_platform_array[i].activeInHierarchy)
                {
                    if(g_platform_array[i].GetComponent<Platform_handler>().g_type == 1)
                    {
                        g_actual_scene_distance = g_individual_sprite_size/2;
                        g_spawn_interval_life_T = g_actual_scene_distance / g_platform.GetComponent<Platform_handler>().g_platform_move_speed;
                    }
                    if (g_platform_array[i].GetComponent<Platform_handler>().g_type == 2)
                    {
                        g_actual_scene_distance = (g_individual_sprite_size * 2.1f)/2;
                        g_spawn_interval_life_T = g_actual_scene_distance / g_platform.GetComponent<Platform_handler>().g_platform_move_speed;
                    }
                    if (g_platform_array[i].GetComponent<Platform_handler>().g_type == 3)
                    {
                        g_actual_scene_distance = (g_individual_sprite_size * 3.1f) / 2;
                        g_spawn_interval_life_T = g_actual_scene_distance / g_platform.GetComponent<Platform_handler>().g_platform_move_speed;
                    }



                    if (l_spawn_point_choice == 1)
                    {
                        g_spawnValue_axisY = -0.05f;
                    }
                    if (l_spawn_point_choice == 2)
                    {
                        g_spawnValue_axisY = -2.5f;
                    }
                    if (l_spawn_point_choice == 3)
                    {
                        g_spawnValue_axisY = -4.95f;
                    }

                    g_platform_array[i].transform.position = new Vector2(g_spawnValue_axisX, g_spawnValue_axisY);

                    g_platform_array[i].SetActive(true);

                    g_spawn_interval_elapsed_T = 0;
                    g_spawn_interval_start_T = Time.time;
                    break;
                }
                
            }
        }
    }

    


    private float m_get_randomValue(float l_min,float l_max)
    {
        return Mathf.RoundToInt(Random.Range(l_min, l_max));
    }

    

    private void m_init_all_platforms()
    {
        for (int i = 0; i < g_platform_count; i++)
        {
            if(i >= 0 && i < 5)
            {
                g_platform_array[i] = Instantiate(g_platform, new Vector2(0, 0), Quaternion.identity);
                g_platform_array[i].transform.name = "platform_" + (i + 1);
            }
            if (i >= 5 && i < 10)
            {
                g_platform_array[i] = Instantiate(g_platform_Enemy_2, new Vector2(0, 0), Quaternion.identity);
                g_platform_array[i].transform.name = "g_platform_Enemy_2_" + (i + 1);
            }
            if (i >= 10 && i < g_platform_count)
            {
                g_platform_array[i] = Instantiate(g_platform_Enemy_3, new Vector2(0, 0), Quaternion.identity);
                g_platform_array[i].transform.name = "g_platform_Enemy_3_" + (i + 1);
            }
            g_platform_array[i].SetActive(false);
        }
    }

    void m_increase_Game_Complexity(float l_change_val)
    {
        g_platform.GetComponent<Platform_handler>().g_platform_move_speed += l_change_val;
        g_platform_Enemy_2.GetComponent<Platform_handler>().g_platform_move_speed += l_change_val;
        g_platform_Enemy_3.GetComponent<Platform_handler>().g_platform_move_speed += l_change_val;
    }
   
}
