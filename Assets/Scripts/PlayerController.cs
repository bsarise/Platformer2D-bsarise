using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleController particleController;

    [Header("이동")]
    public float moveSpeed = 5f;  // 캐릭터 이동속도 변수저장
    public float JumpForce = 10f;
    private float moveInput;  // 플레이어의 방향 및 인풋 데이터 저장

    //public Transform startTransform; // 캐릭터가 시작할 위치를 저장 변수
    public Rigidbody2D rigidbody2D; // 물리(강체) 기능을 제어하는 컴포넌트


    [Header("점프")]
    public bool isGrounded;  // true : 점프가능
    public float groundDistance = 2f;
    public LayerMask groundLayer; // 땅인지 아닌지 레이어 체크

    [Header("Filp")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;

    public Animator animator;
    private bool isMove;

    public bool MoP;



    void Start()
    {
//        Debug.Log("게임을 시작하지");
//        transform.position = new Vector2(transform.position.x, 10);
        rigidbody2D = GetComponent<Rigidbody2D>();
        //transform.position = startTransform.position;

        FallDownCheck();
    }

    void InitializePlayerStatus()
    {
        //transform.position = startTransform.position;
        rigidbody2D.velocity = Vector2.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
    }

    
    void Update()
    {   // 벽 체크
        // bool isWalled = Physics2D.Raycast(transform.position, transform.forward, groundDistance, groundLayer);
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        if (MoP == false){Move();}
        FallDownCheck();
    }

    private void FallDownCheck()
    {
        if(transform.position.y < -11)
        {
            // y의 높이가 특정 지점보다 낮을 때 낙사한 것으로 간주한다.(좋은코드는 아님)
            InitializePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : 현재 rigidbody 속도 = 0 움직이지 않는 상태, !=0 움직이고 있는 상태
        isMove = rigidbody2D.velocity.x != 0; // 1 != 0 ? true
        animator.SetBool("IsMove", isMove);
        animator.SetBool("IsGrounded", isGrounded); //(유니티애님, 비쥬얼애님)
        //SetFloat 함수에 의해 y최대일때 1로 변환, y최소일때 -1로 변환
        //점프 키를 누르면, 순간적으로 y높이 증가, 중력에 의해 점점 y 속도 -까지 내려감
        animator.SetFloat("yVeloctiy", rigidbody2D.velocity.y);
    }

    /// <summary>
    /// 점프시 땅인지 체크 -> collider check
    /// </summary>

    private void CollisionCheck()
    {
        // 점프시 땅인지 체크 -> collider check
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        particleController.isGround = isGrounded;
    }


    /// <summary>
    ///         // 플레이어 입력 받음
    /// </summary>
    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            particleController.PlayParticle();
        }
        JumpButton();
        moveInput = Input.GetAxis("Horizontal");
    }

    private void HandleFlip()
    {
        //오른쪽으로 방향을 바로보고 있을때
        if(facingRight && moveInput <0)
        {
            Flip();
        }

        // 왼쪽 방향으로 바라보고 있을때
        else if(!facingRight && moveInput >0) 
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // 점프 사운드 출력
        // SFX 배열에 등록된 효과음 출력 숫자 2는 Jump1에 해당
        AudioManager.instance.PlaySFX(2);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);
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

    private void PlatformMove(Vector2 power)
    {
        
    }
}

