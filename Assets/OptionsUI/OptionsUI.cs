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
    public Toggle fasterToggle;
    private bool isPaused = false;
    public float timeScale;
    public void Start()
    {
        checkAutoStartState();
        checkFasterState();
        timeScale = 1.5f;
    }   
    
    public void OnEnable()
    {
        // Pause the game when options UI is enabled
        isPaused = true;
        Time.timeScale = 0;
        //Deselect any selected tower
        if(Tower.selectedTower != null)
        {
        Tower.selectedTower.GetComponent<Tower>().hideTowerUI();
        }
    }

    public void OnDisable()
    {
        // Resume the game when options UI is disabled
        isPaused = false;
        Time.timeScale = timeScale;
    }

    public void checkAutoStartState()
    {
        bool autoStart = GameObject.Find("roundManager").GetComponent<roundManager>().autoStart;
        autostartToggle.isOn = autoStart;
        autostartToggle.onValueChanged.AddListener(delegate { autoStartToggle(); });
    }

    public void checkFasterState()
    {
        bool faster = GameObject.Find("roundManager").GetComponent<roundManager>().faster;
        fasterToggle.isOn = faster;
        fasterToggle.onValueChanged.AddListener(delegate { fasterGameToggle(); });
    }

    public void autoStartToggle()
    {
        GameObject.Find("roundManager").GetComponent<roundManager>().autoStart = !GameObject.Find("roundManager").GetComponent<roundManager>().autoStart;
    }

    public void fasterGameToggle()
    {
        GameObject.Find("roundManager").GetComponent<roundManager>().faster = !GameObject.Find("roundManager").GetComponent<roundManager>().faster;
        if(GameObject.Find("roundManager").GetComponent<roundManager>().faster)
        {
            timeScale = 3.0f;
        }
        else
        {
            timeScale = 1.5f;
        }
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
