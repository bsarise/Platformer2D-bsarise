using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleController particleController;

    [Header("�̵�")]
    public float moveSpeed = 5f;  // ĳ���� �̵��ӵ� ��������
    public float JumpForce = 10f;
    private float moveInput;  // �÷��̾��� ���� �� ��ǲ ������ ����

    //public Transform startTransform; // ĳ���Ͱ� ������ ��ġ�� ���� ����
    public Rigidbody2D rigidbody2D; // ����(��ü) ����� �����ϴ� ������Ʈ


    [Header("����")]
    public bool isGrounded;  // true : ��������
    public float groundDistance = 2f;
    public LayerMask groundLayer; // ������ �ƴ��� ���̾� üũ

    [Header("Filp")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;

    public Animator animator;
    private bool isMove;

    public bool MoP;



    void Start()
    {
//        Debug.Log("������ ��������");
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
    {   // �� üũ
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
            // y�� ���̰� Ư�� �������� ���� �� ������ ������ �����Ѵ�.(�����ڵ�� �ƴ�)
            InitializePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : ���� rigidbody �ӵ� = 0 �������� �ʴ� ����, !=0 �����̰� �ִ� ����
        isMove = rigidbody2D.velocity.x != 0; // 1 != 0 ? true
        animator.SetBool("IsMove", isMove);
        animator.SetBool("IsGrounded", isGrounded); //(����Ƽ�ִ�, �����ִ�)
        //SetFloat �Լ��� ���� y�ִ��϶� 1�� ��ȯ, y�ּ��϶� -1�� ��ȯ
        //���� Ű�� ������, ���������� y���� ����, �߷¿� ���� ���� y �ӵ� -���� ������
        animator.SetFloat("yVeloctiy", rigidbody2D.velocity.y);
    }

    /// <summary>
    /// ������ ������ üũ -> collider check
    /// </summary>

    private void CollisionCheck()
    {
        // ������ ������ üũ -> collider check
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        particleController.isGround = isGrounded;
    }


    /// <summary>
    ///         // �÷��̾� �Է� ����
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
        //���������� ������ �ٷκ��� ������
        if(facingRight && moveInput <0)
        {
            Flip();
        }

        // ���� �������� �ٶ󺸰� ������
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
        // ���� ���� ���
        // SFX �迭�� ��ϵ� ȿ���� ��� ���� 2�� Jump1�� �ش�
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

