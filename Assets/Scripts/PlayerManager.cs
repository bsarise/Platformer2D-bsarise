using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playfab;
    [SerializeField] private Transform[] playerPosition; // check point, Save point 시작 위치 변경해주는 기능
    public float speed = 50f;
    public int positionIndex = 0;

    private PlayerController playerController; // playerController에서 빠진 컴포넌트 들을 추가해줘야 한다.
    [SerializeField] private PlayerCam playerCam;  // playerCam 클래스에 접근. RespawnPlayer에서 playerCam에 접근할수 있게 코드를 작성해보라


    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStartPo();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerStartPo();
        }
        // 만약 player 변수가 null이면 Respawn해라
        if(player == null)
        {
            PlayerStartPo();
        }
    }

    private void PlayerStartPo()
    {
        player = Instantiate(playfab, playerPosition[positionIndex].position, Quaternion.identity);
    
        playerController = player.GetComponent<PlayerController>(); // 다른 코드에 접근하는 방법
        //playerController.startTransform = playerPosition[positionIndex];
        playerCam.playerTransform = player.transform;
        playerCam.Setoffset();
    }

    private void NextGoal()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition[positionIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerPosition[positionIndex].position) <= 0.1f)
        {
            positionIndex++;
        }
    }
}
