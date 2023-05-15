using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionsUI : MonoBehaviour
{
    public Button HomeButton;
    public Button RestartButton;
    public Button ContinueButton;
    public Slider SFXslider;
    public Slider MUSICslider;
    public Toggle autostartToggle;
    public Slider MASTERslider;
    public AudioMixer mixer;
    
    public void Start()
    {
        checkAutoStartState();
    }

    public void checkAutoStartState()
    {
        bool autoStart = GameObject.Find("roundManager").GetComponent<roundManager>().autoStart;
        autostartToggle.isOn = autoStart;
        autostartToggle.onValueChanged.AddListener(delegate { autoStartToggle(); });
    }

    public void autoStartToggle()
    {
        GameObject.Find("roundManager").GetComponent<roundManager>().autoStart = !GameObject.Find("roundManager").GetComponent<roundManager>().autoStart;
    }

    public void OnSFXVolumeChanged()
    {
        mixer.SetFloat("SFXVolume", SFXslider.value);
    }

    public void OnMasterVolumeChanged()
    {
        mixer.SetFloat("MasterVolume", MASTERslider.value);
    }

    public void OnMusicVolumeChanged()
    {
        mixer.SetFloat("MusicVolume", MUSICslider.value);
    }
}
