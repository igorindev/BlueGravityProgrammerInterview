using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ItemsDataCollection allGameItems;
    [SerializeField] ItemsDataCollection initialInventory;

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
        playerMoney = new PlayerMoney(850);
        playerInventory = new PlayerInventory(initialInventory.GetAllItemsData());

        playerUI.Setup(playerMoney, playerInventory);
        shopUI.Setup(playerMoney, playerInventory);
        inventoryUI.Setup(playerMoney, playerInventory);
        inventoryUI.Initialize();
        playerMouse.Setup(playerTransform);
        playerInput.Setup(playerTransform);
    }

    void Start()
    {
        playerMoney.BindListenerToMoneyUpdate(playerUI.UpdateMoney);
        playerMoney.RefreshListeners();
    }

    public void ShowShop(NpcShop npcShop, List<ItemInstance> shopItems)
    {
        shopUI.PresentUICanvas(RestorePlayerInput);
        shopUI.SetupShopUI(npcShop, shopItems, inventoryUI);
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
