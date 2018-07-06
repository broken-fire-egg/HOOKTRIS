using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] BGMs;
    public AudioSource[] SFXs;

    public bool BGM, SFX;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayBGM(int BGM_num)
    {
        int a = Mathf.Clamp(BGM_num, 0, BGMs.Length);

        BGMs[a].Play();
    }
    public void StopBGM()
    {
        for (int i = 0; i < BGMs.Length; i++)
            BGMs[i].Stop();
    }
    public void PlaySFX(int SFX_num)
    {
        int a = Mathf.Clamp(SFX_num, 0, SFXs.Length);

        SFXs[a].Play();
    }
}
