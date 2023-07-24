using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ItemsDataCollection allGameItems;
    [SerializeField] ShopUI shopUI;
    [SerializeField] PlayerUI playerUI;

    PlayerMoney playerMoney;
    PlayerInventory playerInventory;

    public enum GameState
    {
        Paused,
        Running
    }

    public static GameState CurrentGameState { get => gameState; }
    static GameState gameState;

    protected override void Awake()
    {
        base.Awake();

        gameState = GameState.Running;
        playerMoney = new PlayerMoney(1000);
        playerInventory = new PlayerInventory(new List<ItemData>());

        playerUI.Setup(playerMoney, playerInventory);
        shopUI.Setup(playerMoney, playerInventory);
    }

    void Start()
    {
        playerMoney.BindListenerToMoneyUpdate(playerUI.UpdateMoney);
        playerMoney.RefreshListeners();
    }

    public void ShowShop(ItemData[] shopItems, int shopId)
    {
        shopUI.PresentShopUI(shopItems, shopId, CloseShop);
    }

    public void CloseShop()
    {
        gameState = GameState.Running;
    }

    public void ShowPlayerUI()
    {

    }
}
