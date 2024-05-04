using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("이동")]
    public float moveSpeed = 5f;  // 캐릭터 이동속도 변수저장
    public float JumpForce = 10f;
    private float moveInput;  // 플레이어의 방향 및 인풋 데이터 저장

    public Transform startTransform; // 캐릭터가 시작할 위치를 저장 변수
    public Rigidbody2D rigidbody2D; // 물리(강체) 기능을 제어하는 컴포넌트


    [Header("점프")]
    public bool isGrounded;  // true : 점프가능
    public float groundDistance = 2f;
    public LayerMask groundLayer; // 땅인지 아닌지 레이어 체크

    void Start()
    {
        Debug.Log("게임을 시작하지");
//        transform.position = new Vector2(transform.position.x, 10);
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = startTransform.position;
    }

    
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2 (moveSpeed * moveInput, rigidbody2D.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            // 점프 구현 : Y Position _ rigidbody Y velocity를 점프 파워만큼 올려주면 된다.
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}
}

