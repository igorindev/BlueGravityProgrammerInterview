using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ItemsDataCollection allGameItems;
    [SerializeField] Shop shop;

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
    }

    public static void ChangeGameSimulation(GameState newState)
    {
        gameState = newState;
    }

    public void ShowShop(ItemData[] shopItems, int shopId)
    {
        shop.Setup(playerMoney, shopItems, shopId);
    }

    public void CloseShop()
    {
        gameState = GameState.Running;
    }
}
