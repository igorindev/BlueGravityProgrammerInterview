using NUnit.Framework.Interfaces;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCost;
    [SerializeField] Image itemSprite;
    [SerializeField] Button button;

    ItemInstance currentItemInstance;

    public void Setup(ItemInstance itemInstance, bool canBuy, Action<ItemInstance> onClickCallback)
    {
        currentItemInstance = itemInstance;
        ItemData itemData = currentItemInstance.itemData;

        itemName.text = itemData.ItemName;
        itemCost.text = itemData.ItemCost.ToString() + " <color=yellow>$</color>";
        itemCost.color = canBuy ? Color.black : Color.red;
        itemSprite.sprite = itemData.ItemSprite;

        button.interactable = canBuy;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClickCallback(itemInstance));
    }

    public bool CheckItemReference(ItemInstance itemInstance)
    {
        return itemInstance == currentItemInstance;
    }
}
