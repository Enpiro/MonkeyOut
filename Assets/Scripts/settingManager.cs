using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class settingManager : MonoBehaviour
{
    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQuality;
    public Slider musicVolume;

    private AudioSource musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSett;
    public Button applyButton;
    private GameObject jungleAudio;

    void OnEnable()
    {
        jungleAudio = GameObject.Find("JungleAudio");

        if (jungleAudio != null)
        {
            musicSource = jungleAudio.GetComponent<AudioSource>();
        }
        gameSett = new GameSettings();

        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreen(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQuality.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolume.onValueChanged.AddListener(delegate { OnMusicCHange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnFullScreen()
    {
       gameSett.fullScreen = Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSett.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
       QualitySettings.masterTextureLimit = gameSett.textureQuality = textureQuality.value;       
    }

    public void OnMusicCHange()
    {
        musicSource.volume = gameSett.audioVolume = musicVolume.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
        SceneManager.LoadScene(0);
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSett,true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json",jsonData);
    }

    public void LoadSettings()
    {
        gameSett = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        musicVolume.value = gameSett.audioVolume;
        textureQuality.value = gameSett.textureQuality;
        resolutionDropdown.value = gameSett.resolutionIndex;
        fullScreenToggle.isOn = gameSett.fullScreen;
        Screen.fullScreen = gameSett.fullScreen;

        resolutionDropdown.RefreshShownValue();
    }
}
