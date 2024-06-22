using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    
    [SerializeField] ParticleSystem PS_Movement; // private 생략
    [SerializeField] ParticleSystem PS_Jump;
    [SerializeField] ParticleSystem PS_My;

    // 플레이어의 속도에 따라 파티클을 생성하는 제어 조건
    [SerializeField] int occurAfterVolocity;


    // 먼지의 생성 주기
    [Range(0, 0.3f)]
    [SerializeField] float dustFormationTime;

    [SerializeField] Rigidbody2D playerRb;

    float counter; // 먼지 생성주기를 체크하기 위한 시간변수
    public bool isGround; // 플레이어의 점프 상태를 체크하기 위한 변수

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
