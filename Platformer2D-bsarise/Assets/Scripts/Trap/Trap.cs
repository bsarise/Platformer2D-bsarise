using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾�� �浹������ �̺�Ʈ(�����) �۵�
// �� ��ü ���� Collider�� ���� �־�� ��
// �浹���ؼ��� �ι�ü���� ������ٵ� 1�� ����
public class Trap : MonoBehaviour
{
    // �浹 �̺�Ʈ �ۼ��Ҷ� ��� ������Ʈ�� ������� �ۼ��� ���� ���� ����
    // ���� ���� �鿡���� ��ȿ����
    // �浹 �̺�Ʈ�� Ư�� ��� �۵��ϵ��� �±�(����ǥ) �޾��ش�. ���� ������Ʈ �� ���� �±� ����
    // Layer - �̺�Ʈ�� �۵� �� �� Ư�� ��� �з����ִ� ����. �� ������Ʈ�� �������� ���̾ ���� �Ҽ� �ִ�.
    // Tag - ������ �浹 �̺�Ʈ���� ���
    // �׷� ������ ������ �� �� ���

    protected bool isWorking = false;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾� �±׸� ������ �ִ°�?
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player�� ������ �ǰ� ����(Collision �浹)");
        }

    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player�� ������ �ǰ� ����(Trigger �浹)");
        }
            
    }

}
