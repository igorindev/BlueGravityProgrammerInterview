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

    ItemData itemData;

    public void Setup(ItemData itemData, bool canBuy, Action<ItemData> onClickCallback)
    {
        this.itemData = itemData;

        itemName.text = itemData.ItemName;
        itemCost.text = itemData.ItemCost.ToString();
        itemCost.color = canBuy ? Color.black : Color.red;
        itemSprite.sprite = itemData.ItemSprite;

        button.interactable = canBuy;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClickCallback(itemData));
    }
}
