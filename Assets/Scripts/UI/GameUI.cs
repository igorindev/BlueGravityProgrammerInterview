using System;
using UnityEngine;
using UnityEngine.UI;

internal interface IUISetup
{
    void Setup(PlayerMoney playerMoney, PlayerInventory playerInventory);
    void PresentUICanvas(Action onCloseUICallback);
}

public class GameUI : MonoBehaviour, IUISetup
{
    [SerializeField] Canvas canvas;
    [SerializeField] Button closeButton;

    protected PlayerMoney playerMoney;
    protected PlayerInventory playerInventory;

    Action onCloseUI;

    public void Setup(PlayerMoney playerMoney, PlayerInventory playerInventory)
    {
        this.playerMoney = playerMoney;
        this.playerInventory = playerInventory;
        
        if (closeButton)
            closeButton.onClick.AddListener(CloseUICanvas);
    }

    public void PresentUICanvas(Action onCloseUICallback)
    {
        onCloseUI = onCloseUICallback;
        canvas.enabled = true;
    }

    public void CloseUICanvas()
    {
        canvas.enabled = false;
        onCloseUI?.Invoke();
    }
}
