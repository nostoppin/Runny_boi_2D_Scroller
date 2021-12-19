using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night_cycle : MonoBehaviour
{
    GameObject g_main_camera;
    public GameObject g_cloud_1;
    public GameObject g_cloud_2;
    public GameObject g_cloud_3;

    float g_LerpVal_toNight = 0;
    float g_LerpVal_toDay = 0;

    private bool g_isCloud;

    Camera g_CameraComp;

    public Color g_Day ;
    Color g_Night = Color.black;
    Color g_Cloud_color;


    bool g_isDay = false;
    // Start is called before the first frame update
    void Start()
    {
        g_main_camera = GameObject.Find("Main Camera");

        g_CameraComp = g_main_camera.GetComponent<Camera>();

        g_Cloud_color = g_cloud_1.GetComponent<SpriteRenderer>().color;

        g_isCloud = true;

        g_isDay = true;

        //g_cloud_1.GetComponent<SpriteRenderer>().color.a
    }

    // Update is called once per frame
    void Update()
    {
        m_color_gradient_modifier();
        
    }

    

    void m_color_gradient_modifier()
    {
        //print(g_isCloud + " " +g_Cloud_color);
        if(g_Cloud_color.a == 0)
        {
            g_isCloud = false;
        }
        if(g_Cloud_color.a == 1)
        {
            g_isCloud = true;
        }

        if (g_isDay && g_isCloud)
        {
            g_CameraComp.backgroundColor = Color.Lerp(g_Day, g_Night, g_LerpVal_toNight);
            g_LerpVal_toNight += 0.05f * Time.deltaTime;

            g_Cloud_color.a = 1 - g_LerpVal_toNight;

            g_cloud_1.GetComponent<SpriteRenderer>().color = g_Cloud_color;
            g_cloud_2.GetComponent<SpriteRenderer>().color = g_Cloud_color;
            g_cloud_3.GetComponent<SpriteRenderer>().color = g_Cloud_color;

            if (g_CameraComp.backgroundColor == g_Night && g_Cloud_color.a < 0)
            {
                g_isDay = !g_isDay;
                g_LerpVal_toNight = 0f;

                g_isCloud = !g_isCloud;
            }

        }
        if(!g_isDay && !g_isCloud)
        {
            g_CameraComp.backgroundColor = Color.Lerp(g_Night, g_Day, g_LerpVal_toDay);
            g_LerpVal_toDay += 0.02f * Time.deltaTime;

           
            g_Cloud_color.a = 0 + g_LerpVal_toDay;

            g_cloud_1.GetComponent<SpriteRenderer>().color = g_Cloud_color;
            g_cloud_2.GetComponent<SpriteRenderer>().color = g_Cloud_color;
            g_cloud_3.GetComponent<SpriteRenderer>().color = g_Cloud_color;
            
            if (g_CameraComp.backgroundColor == g_Day && g_Cloud_color.a > 1)
            {
                g_isDay = !g_isDay;
                g_LerpVal_toDay = 0f;

                g_isCloud = !g_isCloud;
            }
        }
    }
    
}
