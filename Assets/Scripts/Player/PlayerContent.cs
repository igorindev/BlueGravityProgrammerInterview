using System.Collections.Generic;

public class PlayerMoney
{
    int money;

    public PlayerMoney(int money)
    {
        this.money = money;
    }

    public int Money { get => money; }

    public bool HasEnoughMoney(int quantity) => Money >= quantity;

    public void AddMoney(int quantity)
    {
        money += quantity;
    }

    public void SpendMoney(int quantity)
    {
        money -= quantity;
    }
}

public class PlayerInventory
{
    List<ItemData> currentItems;

    public PlayerInventory(List<ItemData> items)
    {
        currentItems = items;
    }

    public List<ItemData> CurrentItems { get => currentItems; }

    public void AddItemToInventory(ItemData itemData)
    {
        currentItems.Add(itemData);
    }

    public void RemoveItemToInventory(ItemData itemData)
    {
        currentItems.Remove(itemData);
    }
}