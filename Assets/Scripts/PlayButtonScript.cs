using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    private GameObject score_saver;
    
    public void LoadFirstLevel()
    {
        score_saver = GameObject.Find("Score_saver");
        if (score_saver != null)
        {
            DontDestroyOnLoad(score_saver);
            ScoreSaverScript score_script = score_saver.GetComponent<ScoreSaverScript>();
            score_script.score = 0;
            score_script.lifes_saver = 3;        
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
