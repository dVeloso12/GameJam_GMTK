using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUiGroup;
    [SerializeField] public bool fadeIn;
    [SerializeField] public bool fadeOut;
    public bool Done;
    private float speed = 0.5f;

    public void ShowUI()
    {
        fadeIn = true;
    }
    public void HideUI()
    {
        fadeOut = true;

    }
    private void Update()
    {
        if(fadeIn)
        {
            if(myUiGroup.alpha < 1)
            {
                myUiGroup.alpha += Time.deltaTime * speed;
                if(myUiGroup.alpha >= 1)
                {
                    fadeIn = false; 
                }
            }
        }
        if (fadeOut)
        {
            if (myUiGroup.alpha >= 0)
            {
                myUiGroup.alpha -= Time.deltaTime * speed;
                if (myUiGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
