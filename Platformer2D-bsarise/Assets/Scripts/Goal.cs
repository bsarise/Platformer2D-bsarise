using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    public GameObject goal;
    

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

            // ȭ�鿡 ������ Ŭ���� �߽��ϴ�. ǥ��. user Interface
            // ���� ����Ʈ ���Ͷ�~
            // ȿ���� ����. ��������� �ٲ��.
        }
    }
}
