using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("�̵�")]
    public float moveSpeed = 5f;  // ĳ���� �̵��ӵ� ��������
    public float JumpForce = 10f;
    private float moveInput;  // �÷��̾��� ���� �� ��ǲ ������ ����

    public Transform startTransform; // ĳ���Ͱ� ������ ��ġ�� ���� ����
    public Rigidbody2D rigidbody2D; // ����(��ü) ����� �����ϴ� ������Ʈ


    [Header("����")]
    public bool isGrounded;  // true : ��������
    public float groundDistance = 2f;
    public LayerMask groundLayer; // ������ �ƴ��� ���̾� üũ

    void Start()
    {
        Debug.Log("������ ��������");
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
            // ���� ���� : Y Position _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ� �ȴ�.
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

