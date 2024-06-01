using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    //벡터의 연산으로 구현

    Vector3 offset;                     // 카메라와 플레이어의 위치 차이
    public Transform playerTransform;   // 플레이엉의 현재 위치(플레이어가 움직일때 변경되고, 카메라가 해당 위치를 차이만큼 쫒아감)
    public float fixedYPosition;        // 카메라의 Y 위치를 고정시키기 위한 기준값
    [Range(0f, 1f)]                     // 아래 변수의 크기를 한정하는 문법. <- C# Attribute
    public float smoothValue;           // 카메라의 선형 보간(부드러운 움직임을 위해) 두 위치 사이에 어느 정도 % 이동할 건지..

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform; //(GameObject) 가져와서 Prefab생성된 PlayerTransform 위치를 이 데이터에 넣어줘야 된다.

        // transform = 카메라, 벡터의 합, 빼기 -> A - B : B에서 출발해서 A까지 이동하는 화살표
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }

    public void Setoffset()
    {
        offset = transform.position - playerTransform.position;
    }

    // Lerp. Linear Interpolateon 선형 보간
    // 양 끝점을 알 때, 두 점 사이의 임의의 위치를 쉽게 파악하기 위한 수학적 개념
    // 두 점(Point) - (Vector3). 카메라의 현재 위치. 이동하고 싶은 위치. 카메라 -> 포인트 - > 목표

    //Vector3.Lerp함수 구현이 되어 있다.

    // Update is called once per frame
    void LateUpdate()
    {
        //플레이어가 움직일 겁니다
      //  offset = transform.position - playerTransform.position;
        

        //벡터의 합 연산으로 카메라의 위치를 구한다.
        Vector3 targetPosition = playerTransform.position + offset;
        // 카메라의 Y(높이)는 고정시킨다.
        targetPosition.y = fixedYPosition;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);  // 0~1사이로

        //벡터의 합, 실제로 플레이어의 x방향으로만 따라다니고, Y는 고정시킨 값으로 카메라를 이동시킨다.
        transform.position = targetPosition;
    }
}
