using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public enum StateToUpdate { NULL,MainMenu_Options, Options_MainMenu, MainMenu_Credits, Credits_MainMenu }
public class MenuManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float Speed = 2f;

    [Header("FadeIN/Out Stuff")]
    [Header("MainMenu")]
    [SerializeField] private GameObject MainMenu;
    [Header("Options")]
    [SerializeField] private GameObject Options;
    [Header("Credits")]
    [SerializeField] private GameObject Credits;

    [Header("Settings Stuff")]
    [SerializeField] AudioMixer Mixer;
    [SerializeField] TMPro.TMP_Dropdown Dropdown_Resolutions;

    private bool _FadeIn, _FadeOut;
    public StateToUpdate state;
    Resolution[] resolutions;

    private void Start()
    {
        state = StateToUpdate.NULL;
        getResolutions();
    }
    private void Update()
    {

        UpdateState();
    }

    #region MenusState
    void UpdateState()
    {
        if(state == StateToUpdate.MainMenu_Options)
        {
            Options.SetActive(true);
            _FadeOut = true;
            FadeIn_FadeOut(MainMenu.GetComponent<CanvasGroup>(), Options.GetComponent<CanvasGroup>(),MainMenu);
            
        }
        if (state == StateToUpdate.Options_MainMenu)
        {
            MainMenu.SetActive(true);
            _FadeOut = true;
            FadeIn_FadeOut(Options.GetComponent<CanvasGroup>(), MainMenu.GetComponent<CanvasGroup>(),Options);
        }
        if (state == StateToUpdate.MainMenu_Credits)
        {
            Credits.SetActive(true);
            _FadeOut = true;
            FadeIn_FadeOut(MainMenu.GetComponent<CanvasGroup>(), Credits.GetComponent<CanvasGroup>(), MainMenu);
        }
        if (state == StateToUpdate.Credits_MainMenu)
        {
            MainMenu.SetActive(true);
            _FadeOut = true;
            FadeIn_FadeOut(Credits.GetComponent<CanvasGroup>(), MainMenu.GetComponent<CanvasGroup>(),Credits);
        }
    }

    public void MainMenu_Options()
    {
        
        state = StateToUpdate.MainMenu_Options;

    }
    public void Options_MainMenu()
    {
        state = StateToUpdate.Options_MainMenu;

    }
    public void MainMenu_Credits()
    {
        state = StateToUpdate.MainMenu_Credits;
    }
    public void Credits_MainMenu()
    {
        state = StateToUpdate.Credits_MainMenu;

    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("alt f4");
    }
    public void Play()
    {
        SceneManager.LoadScene("GameMap", LoadSceneMode.Single);
        Debug.Log("Play");
    }

    void FadeIn_FadeOut(CanvasGroup FristGoup , CanvasGroup SecondGroup, GameObject disable)
    {
        if (_FadeOut)
        {
         if (FristGoup.alpha >= 0)
            {
                FristGoup.alpha -= Time.deltaTime * Speed;
                if (FristGoup.alpha == 0)
                {
                    _FadeOut = false;
                    _FadeIn = true;
                }
            }
        }
        if (_FadeIn)
        {     
            if (SecondGroup.alpha < 1)
            {
                SecondGroup.alpha += Time.deltaTime * Speed;
                if (SecondGroup.alpha >= 1)
                {
                    _FadeIn = false;
                    state = StateToUpdate.NULL;
                    disable.SetActive(false);
                }
            }
        } 
    }
    #endregion
    #region Settings
    void getResolutions()
    {
        resolutions = Screen.resolutions;

        Dropdown_Resolutions.ClearOptions();

        int currentRes = 0;
        List<string> op = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            op.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }
        Dropdown_Resolutions.AddOptions(op);
        Dropdown_Resolutions.value = currentRes;
        Dropdown_Resolutions.RefreshShownValue();

    }
    public void SetVolume(float volume)
    {
        Mixer.SetFloat("volume", volume);
    }
    public void SetQuality(int index)
    {
        Debug.Log(index);
        QualitySettings.SetQualityLevel(index);
    }
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    #endregion

}
