using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_handler : MonoBehaviour
{
    bool g_goingRight;

    public float g_coin_rotateSpeed = 0f;
    
    float max_scale = 0.2f;
    float min_scale = 0.001f;

    private Vector3 g_coin_inital_pos = Vector3.zero;

   
    // Start is called before the first frame update
    void Start()
    {
        g_coin_inital_pos = this.transform.localPosition;

        g_coin_rotateSpeed = 0.5f;

        g_goingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_coin_rotator();
        
        m_game_bounds();
    }
    
    void m_coin_rotator()
    {
        if(g_goingRight)
        {
            this.transform.localScale += Vector3.right * g_coin_rotateSpeed * Time.deltaTime;
            if (this.transform.localScale.x > max_scale)
            {
                g_goingRight = !g_goingRight;
            }
        }
       if (!g_goingRight)
        {
            this.transform.localScale += Vector3.left * g_coin_rotateSpeed * Time.deltaTime;
            if (this.transform.localScale.x < min_scale)
            {
                g_goingRight = !g_goingRight;
            }
        }
        //print(g_goingRight);
    }


    

    void OnCollisionEnter2D(Collision2D l_Collision)
    {
        if (l_Collision.transform.tag == "Player")
        {
            this.gameObject.SetActive(false);
            m_reset_coin_pos();
        }
    }

    void m_game_bounds()
    {
        if (this.transform.position.x < -14f)
        {
            m_reset_coin_pos();
            //this.gameObject.SetActive(false);
        }
    }

    public void m_reset_coin_pos()
    {
        this.transform.localPosition = g_coin_inital_pos;
    }
}
