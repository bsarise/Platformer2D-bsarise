using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    //������ �������� ����

    Vector3 offset;                     // ī�޶�� �÷��̾��� ��ġ ����
    public Transform playerTransform;   // �÷��̾��� ���� ��ġ(�÷��̾ �����϶� ����ǰ�, ī�޶� �ش� ��ġ�� ���̸�ŭ �i�ư�)
    public float fixedYPosition;        // ī�޶��� Y ��ġ�� ������Ű�� ���� ���ذ�
    [Range(0f, 1f)]                     // �Ʒ� ������ ũ�⸦ �����ϴ� ����. <- C# Attribute
    public float smoothValue;           // ī�޶��� ���� ����(�ε巯�� �������� ����) �� ��ġ ���̿� ��� ���� % �̵��� ����..

    // Start is called before the first frame update
    void Start()
    {
        // transform = ī�޶�, ������ ��, ���� -> A - B : B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }

    // Lerp. Linear Interpolateon ���� ����
    // �� ������ �� ��, �� �� ������ ������ ��ġ�� ���� �ľ��ϱ� ���� ������ ����
    // �� ��(Point) - (Vector3). ī�޶��� ���� ��ġ. �̵��ϰ� ���� ��ġ. ī�޶� -> ����Ʈ - > ��ǥ

    //Vector3.Lerp�Լ� ������ �Ǿ� �ִ�.

    // Update is called once per frame
    void LateUpdate()
    {
        //�÷��̾ ������ �̴ϴ�
      //  offset = transform.position - playerTransform.position;
        

        //������ �� �������� ī�޶��� ��ġ�� ���Ѵ�.
        Vector3 targetPosition = playerTransform.position + offset;
        // ī�޶��� Y(����)�� ������Ų��.
        targetPosition.y = fixedYPosition;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);  // 0~1���̷�

        //������ ��, ������ �÷��̾��� x�������θ� ����ٴϰ�, Y�� ������Ų ������ ī�޶� �̵���Ų��.
        transform.position = targetPosition;
    }
}
