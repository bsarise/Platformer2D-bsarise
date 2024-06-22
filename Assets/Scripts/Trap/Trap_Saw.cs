using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions; //��Ϲ����� �̵��� ��ġ�� ������ ����
    public float speed = 5f;
    public int moveIndex = 0;
    public bool OnGoingForward = true;
    public bool IsTrapOn = true;  // MoveTrap �Լ��� �̵� ��ų�� ���� �����ϴ� ����
    public float stopTime = 1f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isWorking = true;
        CoMoveTrap();

        
    }

    private void Update()
    {
        anim.SetBool("isWorking", isWorking);
        // if(���� == true)
        // StartCoroutine(CoMoveTrap()) :  �ڷ�ƾ�� Update���� �Ժη� ����ϸ� �ȵȴ�.
        // IsTrapon�� ���� Moverap�� ���� ��Ű�� ����
        if (IsTrapOn == true)
        {
            MoveTrap();
        }
    }

    IEnumerator CoMoveTrap()
    {
        // ������ 1�� �������� �̵��� �մϴ�.
        //Distance üũ�ؼ� ������ ���������� 1�� ���� �������� �ʽ��ϴ�.
        // ���� ���� ��ġ�� �̵��մϴ�.
        IsTrapOn = false;
        yield return new WaitForSeconds(stopTime);
        IsTrapOn = true;
    }

    private void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed * Time.deltaTime);

        // ���ǹ� - ������ ��ǥ�� �������� �����ߴ°�?
        if (Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex++;
            StartCoroutine(CoMoveTrap());
        }
        // ���� ��ǥ������ ������.. move Index = 0
        if (movePositions.Length <= moveIndex)
        {
            moveIndex = 0;
        }
    }


    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D (collision);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
