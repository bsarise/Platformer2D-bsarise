using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // ����� �ҽ��� �߰����ּ���.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    // ���� �����ϰ� �ִ� BGMIndex
    public int bgmIndex = 0;
    public int sfxIndex = 0;


    private void Awake()
    {
        if(instance == null)
        instance = this; // AudioManager
    }

    public void Start()
    {
        // Debug.Log(bgm.Length);
        // PlayRandomBGM();
    }
    public void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayRandomBGM();
        //}
    }


    public void PlayBGM(int bgmIndex) // bgmIndex�� �ش��ϴ� BGM �����ϴ� �Լ�
    {
        // ������ ����� BGM�� �����.

        bgm[bgmIndex].Play();
    }
    public void PlaySFX(int sfxIndex) 
    {
        if(sfxIndex < sfx.Length)  //sfx.Length ū �� �� ������ �迭�ʰ� ������ �߻��Ѵ�.
        {
            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.15f);
            sfx[sfxIndex].Play();
        }
    }

    private void StopBGM()
    {
        //for(int i = 0; i<bgm.Length; i++)  // �Ʒ��� ������ �ڵ�.
        //{
        //    bgm[i].Stop();
        //}
        foreach (var sound in bgm)
        {
            sound.Stop();
        }

    }

    private void StopSFX()
    {
        for (int i = 0; i < sfx.Length; i++)  // �Ʒ��� ������ �ڵ�.
        {
            sfx[i].Stop();
        }
        //foreach (var sound in bgm)
        //{
        //    sound.Stop();
        //}

    }

    public void PlayRandomBGM()
    {
        StopBGM();
        // bgmIndex�� ������ ���� ������, �� ���� �����ϸ� �ȴ�.
        int randomIndex = Random.Range(0,bgm.Length);
        PlayBGM(randomIndex);
    }
    public void PlayRandomSFX()
    {
        StopSFX();
        // bgmIndex�� ������ ���� ������, �� ���� �����ϸ� �ȴ�.
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);
    }

}
