using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] BGMs;
    public AudioSource[] SFXs;

    public int BGM, SFX;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        BGM = PlayerPrefs.GetInt("BGM", 1);
        SFX = PlayerPrefs.GetInt("SFX", 1);

        for (int i = 0; i < BGMs.Length; i++)
        {
            if (BGM == 1)
                BGMs[i].mute = false;
            else
                BGMs[i].mute = true;
        }

        for (int i = 0; i < SFXs.Length; i++)
        {
            if (SFX == 1)
                SFXs[i].mute = false;
            else
                SFXs[i].mute = true;
        }
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

    public void SFXOn()
    {
        for (int i = 0; i < SFXs.Length; i++)
            SFXs[i].mute = false;
    }
    public void SFXOff()
    {
        if (SFXs[0].isPlaying)
        {
            for (int i = 0; i < SFXs.Length; i++)
                SFXs[i].Pause();
        }
        else
        {
            for (int i = 0; i < SFXs.Length; i++)
                SFXs[i].Play();
        }
    }
    public void BGMOn()
    {
        for (int i = 0; i < BGMs.Length; i++)
            BGMs[i].mute = false;
    }
    public void BGMOff()
    {
        if (BGMs[0].isPlaying)
        {
            for (int i = 0; i < BGMs.Length; i++)
                BGMs[i].Pause();
        }
        else
        {
            for (int i = 0; i < BGMs.Length; i++)
                BGMs[i].Play();
        }
    }
}
