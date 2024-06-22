using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 오디오 소스를 추가해주세요.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public void PlayBGM(int bgmIndex)
    {
        bgm[bgmIndex].Play();
    }
}
