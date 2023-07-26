using System.Collections.Generic;
using UnityEngine;

public class ShopUI : GameUI
{
    [SerializeField] ShopBuyButton[] shopBuyButtons;

    List<ItemInstance> currentShopItemsOptions;

    NpcShop currentNpc;

    public void SetupShopUI(NpcShop npcShop, List<ItemInstance> shopItemsOptions)
    {
        currentNpc = npcShop;

        currentShopItemsOptions = shopItemsOptions;

        RefreshCurrentItems();
    }

    void RefreshCurrentItems()
    {
        for (int i = 0; i < shopBuyButtons.Length; i++)
        {
            if (i < currentShopItemsOptions.Count)
            {
                if (!shopBuyButtons[i].gameObject.activeSelf)
                    shopBuyButtons[i].gameObject.SetActive(true);

                ShopBuyButton shopBuyButton = shopBuyButtons[i];
                bool canBuy = playerMoney.HasEnoughMoney(currentShopItemsOptions[i].itemData.ItemCost);
                shopBuyButton.Setup(currentShopItemsOptions[i], canBuy, Buy);
            }
            else
            {
                shopBuyButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void Buy(ItemInstance itemInstance)
    {
        if (playerInventory.AddItemToInventory(itemInstance))
        {
            GetButtonWithItem(itemInstance).gameObject.SetActive(false);
            currentNpc.RemoveItemFromNpc(itemInstance);
            playerMoney.SpendMoney(itemInstance.itemData.ItemCost);
            RefreshCurrentItems();
        }
        else
        {
            //Inventory is full
        }
    }

    ShopBuyButton GetButtonWithItem(ItemInstance itemInstance)
    {
        for (int i = 0; i < shopBuyButtons.Length; i++)
        {
            if (shopBuyButtons[i].CheckItemReference(itemInstance))
            {
                return shopBuyButtons[i];
            }
        }

        return null;
    }

    public void Sell(ItemInstance itemInstance)
    {
        playerMoney.AddMoney(itemInstance.itemData.ItemCost);
        playerInventory.RemoveItemFromInventory(itemInstance);
        currentNpc.AddItemToNpc(itemInstance);
    }
}
