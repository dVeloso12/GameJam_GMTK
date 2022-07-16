using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManeger : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] GameObject Sound1;
    [SerializeField] GameObject Sound2;
    [SerializeField] GameObject Sound3;

    AudioSource Source1;
    AudioSource Source2;
    AudioSource Source3;

    float timer;
    bool canPlay1, canPlay2, canPlay3,canStopTime;

    private void Start()
    {
        Source1 = Sound1.GetComponent<AudioSource>();
        Source2 = Sound2.GetComponent<AudioSource>();
        Source3 = Sound3.GetComponent<AudioSource>();
        canPlay1 = true;
        canPlay2 = true;
        canPlay3 = true;

    }
    private void Update()
    {
        if(!canStopTime) timer += Time.deltaTime;
        if(canPlay1)
        {
            Source1.Play();
            canPlay1 = false;
        }
        if (timer > 0.5f && canPlay3)
        {
            Source3.Play();
            canPlay3 = false;
            timer = 0f;
            canStopTime = true;
        }
    }


}
