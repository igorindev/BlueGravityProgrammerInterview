using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCost;
    [SerializeField] Image itemSprite;
    [SerializeField] Button button;

    public void Setup(ItemData itemData, Action<int> onClickCallback)
    {
        itemName.text = itemData.ItemName;
        itemCost.text = itemData.ItemCost.ToString();
        itemSprite.sprite = itemData.ItemSprite;

        button.onClick.AddListener(() => onClickCallback(1));
    }
}
