using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ItemsDataCollection allGameItems;
    [SerializeField] ShopUI shopUI;
    [SerializeField] PlayerUI playerUI;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] PlayerMouseInteraction playerInput;
    [SerializeField] Transform playerTransform;

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
        inventoryUI.Setup(playerMoney, playerInventory);
        playerInput.Setup(playerTransform);
    }

    void Start()
    {
        playerMoney.BindListenerToMoneyUpdate(playerUI.UpdateMoney);
        playerMoney.RefreshListeners();
    }

    public void ShowShop(ItemData[] shopItems, int shopId)
    {
        shopUI.PresentShopUI(shopItems, shopId, CloseShop);
        playerInput.InputEnable = false;
    }

    public void CloseShop()
    {
        playerInput.InputEnable = true;
    }

    public void ShowPlayerUI()
    {

    }
    public void ShowPlayerInventory()
    {
        inventoryUI.SetupInventory();
    }
}
