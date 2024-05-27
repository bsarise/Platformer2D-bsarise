using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // ������ �������� ����
    Vector3 offset;
    public Transform playerTransform;
    public float smoothSpeed = 0.015f;
    public float fixedYPosition;
    // Start is called before the first frame update
    void Start()
    {
        // transform = ī�޶�, ������ ��, ����  ->   A - B :   B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ 
        offset = transform.position  - playerTransform.position;
    }

    // �÷��̾��� Update ������ �� ��, ī�޶� ���� �����δ�.
    void LateUpdate()
    {
        // ������ �� - �����̵�
        //transform.position = playerTransform.position + offset;
        // �÷��̾ ������ �̴ϴ�.

        // ī�޶��� Y ����
        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.y = fixedYPosition;
        
        // �ε巯�� ī�޶� �̵�
        Vector3 smoothPosition = Vector3.Lerp(new Vector3(transform.position.x, fixedYPosition, transform.position.z), targetPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

}
