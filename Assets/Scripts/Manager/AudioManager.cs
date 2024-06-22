using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // 오디오 소스를 추가해주세요.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    // 현재 실행하고 있는 BGMIndex
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


    public void PlayBGM(int bgmIndex) // bgmIndex에 해당하는 BGM 실행하는 함수
    {
        // 이전에 실행된 BGM은 멈춰라.

        bgm[bgmIndex].Play();
    }
    public void PlaySFX(int sfxIndex) 
    {
        if(sfxIndex < sfx.Length)  //sfx.Length 큰 수 를 받으면 배열초과 에러가 발생한다.
        {
            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.15f);
            sfx[sfxIndex].Play();
        }
    }

    private void StopBGM()
    {
        //for(int i = 0; i<bgm.Length; i++)  // 아래와 동일한 코드.
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
        for (int i = 0; i < sfx.Length; i++)  // 아래와 동일한 코드.
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
        // bgmIndex가 랜덤한 값을 가지고, 그 값을 실행하면 된다.
        int randomIndex = Random.Range(0,bgm.Length);
        PlayBGM(randomIndex);
    }
    public void PlayRandomSFX()
    {
        StopSFX();
        // bgmIndex가 랜덤한 값을 가지고, 그 값을 실행하면 된다.
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);
    }

}
