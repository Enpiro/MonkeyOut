using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class menuManagerScript : MonoBehaviour {

    public GameObject continue_button;
    public GameObject ananas_image;
    public GameSettings gameSett;
    public AudioSource musicSource;

    private GameObject score_saver;
    private GameObject jungleAudio;

    void Start()
    {
        LoadSettings();
    }
    // Use this for initialization
    void Update ()
    {

        score_saver = GameObject.Find("Score_saver");
        if (score_saver != null)
        {
            DontDestroyOnLoad(score_saver);
            ScoreSaverScript score_script = score_saver.GetComponent<ScoreSaverScript>();
            if (score_script.score == 0 || score_script.lifes_saver == 1)
            {
                continue_button.SetActive(false);
                ananas_image.SetActive(false);
            }
            else
            {
                ananas_image.SetActive(true);
                continue_button.SetActive(true);
            }
        }

        jungleAudio = GameObject.Find("JungleAudio");
        if(jungleAudio != null)
        {
            DontDestroyOnLoad(jungleAudio);
        }

    }

    public void LoadSettings()
    {
        gameSett = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        musicSource.volume = gameSett.audioVolume;
    }

}
