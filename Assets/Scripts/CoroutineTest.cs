using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTest : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {


        Debug.Log("�׳� ȣ��1");
        StartCoroutine(CoTest());
        SubTest();
        StartCoroutine(CoTest2());
        Debug.Log("�׳� ȣ��2");
    }

    // �ڷ�ƾ ������
    IEnumerator CoTest()
    {
        Debug.Log("[�ڷ�ƾ1] : 01ȣ��");
        Debug.Log("[�ڷ�ƾ1] : 02ȣ��");
        yield return new WaitForSeconds(3);
        Debug.Log("[�ڷ�ƾ1] : 03ȣ��");
    }

    IEnumerator CoTest2()
    {
        Debug.Log("[�ڷ�ƾ2] : 01ȣ��");
        Debug.Log("[�ڷ�ƾ2] : 02ȣ��");
        yield return new WaitForSeconds(2);
        Debug.Log("[�ڷ�ƾ2] : 03ȣ��");
    }


    void SubTest()
    {
        Debug.Log("[���� �׽�Ʈ �Լ�] : 01ȣ��");
        Debug.Log("[���� �׽�Ʈ �Լ�] : 02ȣ��");
        Debug.Log("[���� �׽�Ʈ �Լ�] : 03ȣ��");
    }

}
