﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerWithLock : Object
{
    DataManager data;
    SaveDataClass saveData;
    SaveAlarm saveAlarm;

    public bool isB4LockUnlocked;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject researchRecord;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        saveAlarm = FindObjectOfType<SaveAlarm>();
        isB4LockUnlocked = saveData.isB4LockUnlocked;
        if(isB4LockUnlocked)
        {
            lockImage.SetActive(false);
        }
        
    }

    public override void ObjectFunction()
    {
        if(!isB4LockUnlocked)
        {
            saveAlarm.SaveAlarmPopUp();
            lockObj.SetActive(true);
        }
        else
        {
            researchRecord.SetActive(true);
        }
    }
}
