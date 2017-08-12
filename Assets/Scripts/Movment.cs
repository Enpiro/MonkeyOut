using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movment : MonoBehaviour {


    public Rigidbody2D g_directionMove;
    public Rigidbody2D g_jumpForce;
    public float g_force;
    public int int_flagJump = 0;
    public Text life_count_text;

    private bool jump_flag = false;
    private string curent_text;


    void Start()
    {
        curent_text = life_count_text.text;
      
    }
	// Aplicarea miscarii componentei player la apasarea butoanelor dreapta sitnga si saritura componentei maimuta la apasarea space.
	void FixedUpdate ()
    {
        float g_direction = Input.GetAxis("Horizontal");
        Vector2 g_movement = new Vector2(g_direction,0.0f);
        //g_directionMove.AddForce(g_movement*g_force);
        g_directionMove.velocity = g_movement*g_force;
        

        if (jump_flag == false)
        {
            g_jumpForce.velocity = g_movement * g_force;
            if (Input.GetButtonDown("Jump"))
            {
                g_jumpForce.AddForce(Vector2.up * 350);
                jump_flag = true;
                int_flagJump = 1;
            }
        }

        if (curent_text != life_count_text.text)
        {
            jump_flag = false;
            int_flagJump = 0;
            curent_text = life_count_text.text;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}
}
