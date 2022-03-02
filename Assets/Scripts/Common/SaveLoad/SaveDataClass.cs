﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    //인벤토리 및 아이템
    

    //지하 1층
    public bool isFirstGB;
    public bool isUnlocked;
    public bool isDiaryClicked;

    //지하 2층
    public bool alreadyOpen;
    
    //지하 3층
    public bool isPianoMemoGained;
    public bool monsterExtractinInventory; 
    public bool isMonsterDisappear;
    public bool isB4DoorOpened;

    //지하 4층
    public bool isDaggerPicked;
    public bool isJewelGained;
    public bool isB4LockUnlocked;

    public SaveDataClass()
    {
        //인벤토리 및 아이템
        

        //지하 1층
        isFirstGB = true;
        isUnlocked = false;
        isDiaryClicked = false;

        //지하 2층
        alreadyOpen = false;

        //지하 3층
        isMonsterDisappear = false;
        isPianoMemoGained = false;
        monsterExtractinInventory = false; //이거 좀 봐야할 듯
        isB4DoorOpened = false;

        //지하 4층
        isDaggerPicked = false;
        isJewelGained = false;
        isB4LockUnlocked = false;
    }
}
