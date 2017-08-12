using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continueButton : MonoBehaviour {

    private GameObject score_saver;

    public void LoadFirstLevel()
    {
        score_saver = GameObject.Find("Score_saver");
        if (score_saver != null)
        {
            DontDestroyOnLoad(score_saver);
            ScoreSaverScript score_script = score_saver.GetComponent<ScoreSaverScript>();
            SceneManager.LoadScene(score_script.currentLevel);

        }
    }
}
