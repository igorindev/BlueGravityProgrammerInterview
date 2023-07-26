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
            onMoneyUpdated?.Invoke(money);
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

public class ItemInstance
{
    public ItemData itemData;
    public bool equipped;
}

public class PlayerInventory
{
    Action<List<ItemData>> onInventoryUpdated;

    readonly List<ItemInstance> items = new List<ItemInstance>(27);

    readonly List<ItemData> currentItems = new List<ItemData>(27);
    public List<ItemInstance> Items => items;

    public PlayerInventory(ItemData[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            ItemData item = items[i];
            ItemInstance itemInstance = new ItemInstance()
            {
                itemData = item,
            };

            AddItemToInventory(itemInstance);
        }
    }

    bool HasSlotAvailable()
    {
        return items.Count < items.Capacity;
    }

    public bool AddItemToInventory(ItemInstance itemInstance)
    {
        if (HasSlotAvailable())
        {
            items.Add(itemInstance);
            onInventoryUpdated?.Invoke(currentItems);
            return true;
        }

        return false;
    }

    public void RemoveItemFromInventory(ItemInstance itemToRemove)
    {
        items.Remove(itemToRemove);
        onInventoryUpdated?.Invoke(currentItems);
    }
}