using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�׳� ȣ��1");
        StartCoroutine(CoTest());
        SubTest();
        Debug.Log("�׳� ȣ��2");
    }

    // �ڷ�ƾ ������
    IEnumerator CoTest()
    {
        Debug.Log("[�ڷ�ƾ] : 01ȣ��");
        Debug.Log("[�ڷ�ƾ] : 02ȣ��");
        yield return new WaitForSeconds(1);
        Debug.Log("[�ڷ�ƾ] : 03ȣ��");
    }

    void SubTest()
    {
        Debug.Log("[���� �׽�Ʈ �Լ�] : 01ȣ��");
        Debug.Log("[���� �׽�Ʈ �Լ�] : 02ȣ��");
        Debug.Log("[���� �׽�Ʈ �Լ�] : 03ȣ��");
    }

}
