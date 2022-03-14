﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Branch : Object
{ 
    public GameObject branchUI;
    public Sprite branchItemImg;
    public Text branchText;
    public Text inputTextUI;
    B3UIManager uiManager;
    InventoryMng inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        if(this.transform.parent.gameObject.layer != 10 && saveData.isBranchPicked)
        {
            this.gameObject.SetActive(false);
        }

        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        branchUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(branchText.text, inputTextUI));
        GameObject branch = this.gameObject;
        inventoryMng.PickUp(branch, 0.4f, ItemClass.ItemPrefabOrder.Branch);

        saveData.isBranchPicked = true;
        data.Save();
    }
    public void BranchItem()
    {
        if(labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                slotSelectMng.UnselectSlot(this.gameObject);
                //branch_AfterUI.SetActive(true);
                //StartCoroutine(uiManager.LoadTextOneByOne(branch_AfterText.text, inputTextUI));
            }  
        }
        else if(labtableMng.labTable.activeSelf==true) 
        {
            labtableMng.InsertMaterial(this.gameObject);
        }
    }

    public override void ItemActive()
    {
        labtableMng.itemActive["branchActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["branchActive"] = false;
    }

    public override void GetItemName()
    {
        slotSelectMng.itemName = "나뭇가지";
    }
}
