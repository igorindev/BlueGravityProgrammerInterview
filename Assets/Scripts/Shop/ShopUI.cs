using System;
using UnityEngine;

public class ShopUI : GameUI
{
    [SerializeField] ShopBuyButton baseButtonPrefab;
    [SerializeField] Transform container;

    int lastShopId;

    Action onCloseUI;

    ItemData[] currentShopItemsOptions;

    public void PresentShopUI(ItemData[] shopItemsOptions, int shopId, Action onCloseUICallback)
    {
        onCloseUI = onCloseUICallback;

        SetCanvasActive(true);
        if (lastShopId == shopId) return;

        ClearOldShopValues();
        lastShopId = shopId;

        currentShopItemsOptions = shopItemsOptions;

        for (int i = 0; i < shopItemsOptions.Length; i++)
        {
            int id = i;
            ShopBuyButton shopBuyButton = Instantiate(baseButtonPrefab, container);
            bool canBuy = playerMoney.HasEnoughMoney(shopItemsOptions[i].ItemCost);
            shopBuyButton.Setup(shopItemsOptions[i], canBuy, Buy);
        }
    }

    public void CloseShop()
    {
        SetCanvasActive(false);
        onCloseUI.Invoke();
    }

    public void ClearOldShopValues()
    {
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }

    void RefreshCurrentItems()
    {
        for (int i = 0; i < container.childCount; i++)
        {
            int id = i;
            ShopBuyButton shopBuyButton = container.GetChild(i).GetComponent<ShopBuyButton>();
            bool canBuy = playerMoney.HasEnoughMoney(currentShopItemsOptions[i].ItemCost);
            shopBuyButton.Setup(currentShopItemsOptions[i], canBuy, Buy);
        }
    }

    public void Buy(ItemData itemData)
    {
        playerMoney.SpendMoney(itemData.ItemCost);
        playerInventory.AddItemToInventory(itemData);

        RefreshCurrentItems();
    }

    public void Sell(ItemData itemData)
    {
        playerMoney.AddMoney(itemData.ItemCost);
        playerInventory.RemoveItemFromInventory(itemData);
    }
}
