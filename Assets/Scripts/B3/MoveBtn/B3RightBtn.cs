﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3RightBtn : MonoBehaviour
{
    public GameObject playerObj; //public이어서 유니티 에디터에서 접근 가능
    public GameObject creatureEye;
    bool OnClick; //버튼 눌렸는지 떼어졌는지 판단하는 함수
    Player player;    


    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // 매 프레임마다 작동
    void Update()
    {
        if(player.currRoom == "B3_Hallway")
        {
            RightLimit(37.7f);
        }
        else if(player.currRoom == "B3_Treeroom")
        {
            RightLimit(21.6f);
        }
        else if(player.currRoom == "B3_Pianoroom")
        {
            RightLimit(17.4f);
        }
    }
    
    private void RightLimit(float limit)
    {
        if (OnClick && playerObj.transform.position.x < limit)
        {
            playerObj.transform.position += Vector3.right * player.speed * Time.deltaTime;
            if(player.currRoom=="B3_Pianoroom")
            {
                if (OnClick && player.transform.position.x < 11 && player.transform.position.x > -13)
                {
                    creatureEye.transform.position += Vector3.right * player.speed / 8 * Time.deltaTime;
                }
            }
        }
    }
    public void RightBtnUp() //버튼에서 손 뗐을 때
    {
        OnClick = false; //OnClick false됨
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void RightBtnDown() //버튼 눌렸을 때
    {
        OnClick = true; //OnClick true됨
        player.GetComponent<Animator>().SetBool("isWalking", true);
        //playerMng.raycastDir = new Vector3(1, 0, 0); //레이저 방향을 오른쪽으로 설정
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
}

