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
            
            Debug.Log("�÷��̾ ��ǥ������ �����߽��ϴ�");
            
            goal.SetActive(true);
            if (goal.GetComponent <TMP_Text>() != null)
            {
                TMP_Text goalText = goal.GetComponent<TMP_Text>();
                goalText.text = "���� Ŭ����!";                           
            }

            if(PS_C.GetComponent<ParticleSystem>() != null)
            {
                PS_C.SetActive(true);
                // PS_C.GetComponent<ParticleSystem>().Play();
            }

            // ȭ�鿡 ������ Ŭ���� �߽��ϴ�. ǥ��. user Interface
            // ���� ����Ʈ ���Ͷ�~
            // ȿ���� ����. ��������� �ٲ��.
        }
    }
}
