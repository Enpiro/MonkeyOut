using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadInformationScript : MonoBehaviour
{

    public Text WinLoseTexting;
    public Text ScoreTexting;

    private GameObject score_saver;
    private ScoreSaverScript score_script;

    void Start()
    {
        score_saver = GameObject.Find("Score_saver");
        if (score_saver != null)
        {
            DontDestroyOnLoad(score_saver);
            score_script = score_saver.GetComponent<ScoreSaverScript>();

            WinLoseTexting.text = score_script.WinLosseText;
            ScoreTexting.text = "Score: " + score_script.score.ToString();
        }
    }

    public void RestartGame()
    {
        if (score_saver != null)
        {
            score_script.score = 0;
            score_script.WinLosseText = "";
            score_script.lifes_saver = 3;
        }
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
