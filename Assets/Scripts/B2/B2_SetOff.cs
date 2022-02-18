﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_SetOff : MonoBehaviour
{
    B2_UIManager uiManager;
    Text inputTextUI;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inputTextUI = uiManager.inputTextUI;
    }

    public void Off()
    {
        if (!uiManager.nowTexting)
        {
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}