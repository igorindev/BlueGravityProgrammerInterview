using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ItemsDataCollection allGameItems;

    [Header("UI")]
    [SerializeField] ShopUI shopUI;
    [SerializeField] PlayerUI playerUI;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] PauseUI pauseUI;

    [Header("Player")]
    [SerializeField] PlayerMouseInteraction playerMouse;
    [SerializeField] PlayerInput playerInput;
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
        playerMouse.Setup(playerTransform);
        playerInput.Setup(playerTransform);
    }

    void Start()
    {
        playerMoney.BindListenerToMoneyUpdate(playerUI.UpdateMoney);
        playerMoney.RefreshListeners();
    }

    public void ShowShop(ItemData[] shopItems, int shopId)
    {
        shopUI.SetupShopUI(shopItems, shopId);
        shopUI.PresentUICanvas(RestorePlayerInput);
        DisablePlayerInput();
    }

    public void ShowPlayerInventory() //Unity Event
    {
        inventoryUI.PresentUICanvas(RestorePlayerInput);
        inventoryUI.SetupInventory();
        DisablePlayerInput();
    }

    public void ShowPauseGame() //Unity Event
    {
        pauseUI.PresentUICanvas(RestorePlayerInput);
        DisablePlayerInput();
    }

    void RestorePlayerInput()
    {
        playerMouse.InputEnable = true;
        playerInput.InputEnable = true;
    }

    void DisablePlayerInput()
    {
        playerMouse.InputEnable = false;
        playerInput.InputEnable = false;
    }
}
