using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    public GameObject goal;
    public GameObject PS_C;
    private ParticleSystem CP;
    private void Start()
    {
        PS_C = GameObject.Find("PS_Clear");
        CP = PS_C.GetComponent<ParticleSystem>();
        PS_C.SetActive(false); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            Debug.Log("플레이어가 목표지점에 도달했습니다");
            
            goal.SetActive(true);
            if (goal.GetComponent <TMP_Text>() != null)
            {
                TMP_Text goalText = goal.GetComponent<TMP_Text>();
                goalText.text = "게임 클리어!";                           
            }

            if(PS_C.GetComponent<ParticleSystem>() != null)
            {
                PS_C.SetActive(true);
                // PS_C.GetComponent<ParticleSystem>().Play();
            }

            // 화면에 게임을 클리어 했습니다. 표시. user Interface
            // 폭죽 이펙트 나와라~
            // 효과음 사운드. 배경음악이 바뀐다.
        }
    }
}
