using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{
    public GameObject TestObject;
    // NullRefeernce����. ������ �����Ͱ� ��� �߻��ϴ� ������. �ذ��ϱ� ���ؼ� ������ �ʱ�ȭ
    // ����(�ʱ�ȭ) �̺�Ʈ �Լ��� ������ ������ �Ҵ��ϴ� �۾�
    //Awake ->> OnEnable -> Start

    private void Awake()
    {
        Debug.Log("Awake ����");
    }

    private void Start()
    {
        Debug.Log("Start ����");
        TestObject.SetActive(false);

    }

    private void OnEnable()
    {
        Debug.Log("OnEnable ����");
        TestObject = new GameObject();
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate ����");
    }
    private void Update()
    {
        Debug.Log("Update ����");
    }
    private void LateUpdate()
    {
        Debug.Log("LateUpdate ����");
    }
}
