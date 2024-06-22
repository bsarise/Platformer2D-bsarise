using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// UI - Slider ������Ʈ�� �ִ� ������Ʈ�� �� Ŭ���� (����) �ؾ� �Ѵ�.
/// </summary>
public class VolumeController : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Slider slider;
    public string mixerParameterName; // BGM, SFX �ۼ����ִ� ����
    public float sliderMultiPlier; // ~1, 0 ������ Slider Value�� �� ũ�� ���̱� ���� ����


    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(SliderValue);
        slider.minValue = 0.0001f;
    }

    public void SliderValue(float value)
    {

        AudioMixer.SetFloat(mixerParameterName, Mathf.Log10(value) * sliderMultiPlier);
        Debug.Log(Mathf.Log10(value));
    }

}
