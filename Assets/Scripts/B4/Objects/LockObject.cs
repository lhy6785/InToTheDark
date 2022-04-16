﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockObject : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;

    public GameObject monster;
    public GameObject laboratory;
    public GameObject brokenCapsule;

    LockerWithLock lockerWithLock;
    RedJewel redJewel;
    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    [SerializeField] private GameObject lockHole;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject lockUIObj;
    [SerializeField] private GameObject researchRecord;
    [SerializeField] private GameObject DoorToB5Obj;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;

        redJewel = FindObjectOfType<RedJewel>();
        lockerWithLock = FindObjectOfType<LockerWithLock>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void Unlock()
    {
        redJewel = FindObjectOfType<RedJewel>();
        if(redJewel && redJewel.isJewelOnHand)
        {
            Color color = lockHole.GetComponent<Image>().color;
            color.a = 1f;
            lockHole.GetComponent<Image>().color = color;
            inventoryMng.RemoveFromInventory(redJewel.gameObject, ItemClass.ItemPrefabOrder.RedJewel);
            inst.EffectPlay(inst.unlockEffect);
            Invoke("AfterUnlocked", 2f);
        }
    }

    private void AfterUnlocked()
    {
        researchRecord.SetActive(true);
        lockerWithLock.isB4LockUnlocked = true;
        saveData.isB4LockUnlocked = true;
        saveData.isB5DoorOpened = true;
        DoorToB5Obj.GetComponent<DoorToB5>().isB5DoorOpened = true;
        DoorToB5Obj.transform.GetChild(1).gameObject.SetActive(false);
        DoorToB5Obj.transform.GetChild(2).gameObject.SetActive(true);
        lockObj.SetActive(false);
        lockUIObj.SetActive(false);
        data.Save();
        brokenCapsule.SetActive(true);
        Instantiate(monster, new Vector3(-9.57f, 0.75f, 0f), Quaternion.identity, laboratory.transform);
        inst.EffectPlay(inst.capsuleBrokenEffect);
    }
}
