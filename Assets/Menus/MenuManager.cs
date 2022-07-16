using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StateToUpdate { NULL,MainMenu_Options, Options_MainMenu, MainMenu_Credits, Credits_MainMenu }
public class MenuManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float Speed = 2f;

    [Header("MainMenu")]
    [SerializeField] private GameObject MainMenu;
    [Header("Options")]
    [SerializeField] private GameObject Options;
    [Header("Credits")]
    [SerializeField] private GameObject Credits;

    private bool _FadeIn, _FadeOut;
    public StateToUpdate state;
    private bool CanUpdate;
    private void Start()
    {
        state = StateToUpdate.NULL;
    }
    private void Update()
    {

        UpdateState();
    }
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
        SceneManager.LoadScene("GameMap", LoadSceneMode.Additive);
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
 

}
