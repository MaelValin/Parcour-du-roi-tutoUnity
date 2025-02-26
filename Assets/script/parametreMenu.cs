using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class parametreMenu : MonoBehaviour
{

     public AudioMixer audioMixer;

     public Dropdown resolutionDropdown;

     Resolution[] resolutions;

     public Slider musicslider;
     public Slider effectslider;

    public void Start()
    {
        audioMixer.GetFloat("volumeMusic", out float volumevalueslidermusic);
        musicslider.value=volumevalueslidermusic;

        audioMixer.GetFloat("volumeEffect", out float volumevalueslidereffect);
        effectslider.value=volumevalueslidereffect;

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        } 

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
        
    }

    public void SetQuality(int qualityIndex)
    {
        Debug.Log(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volumeMusic", volume);
        
    }

    public void SetVolumeEffect(float volume)
    {
        audioMixer.SetFloat("volumeEffect", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
