using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playfab;
    [SerializeField] private Transform[] playerPosition; // check point, Save point ���� ��ġ �������ִ� ���
    public float speed = 50f;
    public int positionIndex = 0;

    private PlayerController playerController; // playerController���� ���� ������Ʈ ���� �߰������ �Ѵ�.
    [SerializeField] private PlayerCam playerCam;  // playerCam Ŭ������ ����. RespawnPlayer���� playerCam�� �����Ҽ� �ְ� �ڵ带 �ۼ��غ���


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
        // ���� player ������ null�̸� Respawn�ض�
        if(player == null)
        {
            PlayerStartPo();
        }
    }

    private void PlayerStartPo()
    {
        player = Instantiate(playfab, playerPosition[positionIndex].position, Quaternion.identity);
    
        playerController = player.GetComponent<PlayerController>(); // �ٸ� �ڵ忡 �����ϴ� ���
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
