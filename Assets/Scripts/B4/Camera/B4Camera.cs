﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Camera : CameraScript
{
    FloorTxt Ft;

   new void Start()
    {
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        //player.currRoom = "B4_Hallway";
        saveData.currFloor = "B4";
        //saveData.currRoomPos = "이형체의 복도";
        data.Save();
        Ft.PosUI();
    }

    // Update is called once per frame
    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if(saveData.currRoomPos == "이형체의 복도")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if(saveData.currRoomPos == "예배당")
        {
            CameraLimit(-4.6f, 4.6f);
        }
        else if(saveData.currRoomPos == "수상한 실험실")
        {
            CameraLimit(-8.22f, 8.22f);
        }
    }
}
