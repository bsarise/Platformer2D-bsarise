using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ����� �ҽ��� �߰����ּ���.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public void PlayBGM(int bgmIndex)
    {
        bgm[bgmIndex].Play();
    }
}
