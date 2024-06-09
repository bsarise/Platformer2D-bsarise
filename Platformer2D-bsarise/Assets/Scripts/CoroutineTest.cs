using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("그냥 호출1");
        StartCoroutine(CoTest());
        SubTest();
        Debug.Log("그냥 호출2");
    }

    // 코루틴 선언방법
    IEnumerator CoTest()
    {
        Debug.Log("[코루틴] : 01호출");
        Debug.Log("[코루틴] : 02호출");
        yield return new WaitForSeconds(1);
        Debug.Log("[코루틴] : 03호출");
    }

    void SubTest()
    {
        Debug.Log("[서브 테스트 함수] : 01호출");
        Debug.Log("[서브 테스트 함수] : 02호출");
        Debug.Log("[서브 테스트 함수] : 03호출");
    }

}
