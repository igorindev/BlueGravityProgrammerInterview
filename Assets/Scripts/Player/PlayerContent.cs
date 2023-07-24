using System;
using System.Collections.Generic;

public class PlayerMoney
{
    Action<int> onMoneyUpdated;

    int money;

    public PlayerMoney(int money)
    {
        this.money = money;
    }

    ~PlayerMoney()
    {
        onMoneyUpdated = null;
    }

    public int Money
    {
        get => money;
        private set
        {
            money = value;
            onMoneyUpdated.Invoke(money);
        }
    }

    public void BindListenerToMoneyUpdate(Action<int> onMoneyUpdated)
    {
        this.onMoneyUpdated += onMoneyUpdated;
    }
    public void RemoveListenerToMoneyUpdate(Action<int> onMoneyUpdated)
    {
        this.onMoneyUpdated -= onMoneyUpdated;
    }

    public void RefreshListeners()
    {
        onMoneyUpdated.Invoke(money);
    }

    public bool HasEnoughMoney(int quantity) => Money >= quantity;

    public void AddMoney(int quantity)
    {
        Money += quantity;
    }

    public void SpendMoney(int quantity)
    {
        Money -= quantity;
    }
}

public class PlayerInventory
{
    public Action<List<ItemData>> onInventoryUpdated;

    List<ItemData> currentItems;
    public List<ItemData> CurrentItems
    {
        get => currentItems;
        private set
        {
            currentItems = value;
            onInventoryUpdated.Invoke(currentItems);
        }
    }

    public PlayerInventory(List<ItemData> items)
    {
        currentItems = items;
    }

    public void AddItemToInventory(ItemData itemData)
    {
        currentItems.Add(itemData);
    }

    public void RemoveItemFromInventory(ItemData itemData)
    {
        currentItems.Remove(itemData);
    }
}