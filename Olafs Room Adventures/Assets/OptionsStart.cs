using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsStart : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown resolutionsDropdown;

    public GameObject qualitymenu, soundmenu, self, main;

    private float currentVolume = 0;

    private bool mute = false;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionsIndex = 0;
        for (int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionsIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionsIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    void Update()
    {
        //Debug.Log(AudioListener.volume);   
    }

    public void SetVolume(float volume)
    {
        if (!mute)
        {
            AudioListener.volume = volume;
        }
    }

    public void toggleMute(bool muted)
    {
        if (muted)
        {
            currentVolume = AudioListener.volume;
            AudioListener.volume = 0;
        }
        if (!muted)
        {
            AudioListener.volume = currentVolume;
        }
        mute = muted;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVideo()
    {
        soundmenu.SetActive(false);
        qualitymenu.SetActive(true);
    }

    public void SetAudio()
    {
        qualitymenu.SetActive(false);
        soundmenu.SetActive(true);
    }

    public void back()
    {
        self.SetActive(false);
        main.SetActive(true);
    }
}
