using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    protected PlayerMoney playerMoney;
    protected PlayerInventory playerInventory;

    public void Setup(PlayerMoney playerMoney, PlayerInventory playerInventory)
    {
        this.playerMoney = playerMoney;
        this.playerInventory = playerInventory;
    }

    public void SetCanvasActive(bool value)
    {
        canvas.enabled = value;
    }
}
