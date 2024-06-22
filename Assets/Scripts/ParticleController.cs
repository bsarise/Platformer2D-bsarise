using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    
    [SerializeField] ParticleSystem PS_Movement; // private ����
    [SerializeField] ParticleSystem PS_Jump;
    [SerializeField] ParticleSystem PS_My;

    // �÷��̾��� �ӵ��� ���� ��ƼŬ�� �����ϴ� ���� ����
    [SerializeField] int occurAfterVolocity;


    // ������ ���� �ֱ�
    [Range(0, 0.3f)]
    [SerializeField] float dustFormationTime;

    [SerializeField] Rigidbody2D playerRb;

    float counter; // ���� �����ֱ⸦ üũ�ϱ� ���� �ð�����
    public bool isGround; // �÷��̾��� ���� ���¸� üũ�ϱ� ���� ����

    private void Update()
    {
        CheckAfterVolocity();
    }

    public void PlayParticle()
    {
        PS_My.Play();
    }


    private void CheckAfterVolocity()
    {
        counter += Time.deltaTime;
        if (isGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVolocity)
        {
            CheckDustFormationTime();
        }
    }
    
    private void CheckDustFormationTime()
    {
        if (counter > dustFormationTime)
        {
            PS_Movement.Play();
            counter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            PS_Jump.Play();
            isGround = true;
        }    
    }
}
