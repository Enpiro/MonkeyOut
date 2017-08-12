using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSaverScript : MonoBehaviour {


    public int score;
    public int lifes_saver;
    public int currentLevel;
    public string WinLosseText;

    private GameObject ball_obj;

	// Update is called once per frame
	void Update ()
    {
        ball_obj = GameObject.Find("ball_obj");
        int memorized = SceneManager.GetActiveScene().buildIndex;
        if (memorized != 0 && memorized != 7)
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }

        if (ball_obj != null)
        {
            ball_events ballScript = ball_obj.GetComponent<ball_events>();
            score = ballScript.count;
            if (ballScript.life == 0)
            {
                lifes_saver = 3;
            }
            else
            {
                lifes_saver = ballScript.life;
            }
        }
	}
}
