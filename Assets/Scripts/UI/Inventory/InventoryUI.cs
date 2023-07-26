using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : GameUI
{
    [Header("Portrait")]
    [SerializeField] Image face;
    [SerializeField] Image hood;
    [SerializeField] Image pelvis;
    [SerializeField] Image torso;

    [Header("Grid")]
    [SerializeField] CharacterCustomization customizations;
    [SerializeField] Sprite emptySprite;
    [SerializeField] Image[] inventoryGrid;
    [SerializeField] Transform gridParentTransform;
    [SerializeField] Transform gridTransform;

    ItemInstance faceItem;
    ItemInstance hoodItem;
    ItemInstance pelvisItem;
    ItemInstance torsoItem;

    Button[] gridButtons;

#if UNITY_EDITOR
    /// <summary>
    /// Auto get all grid slots
    /// </summary>
    /// 
    void OnValidate()
    {
        if (gridTransform == null) return;
        inventoryGrid = new Image[gridTransform.childCount];
        for (int i = 0; i < gridTransform.childCount; i++)
        {
            inventoryGrid[i] = gridTransform.GetChild(i).GetChild(0).GetComponent<Image>();
        }
    }
#endif

    public void Initialize()
    {
        gridButtons = new Button[inventoryGrid.Length];
        for (int i = 0; i < inventoryGrid.Length; i++)
        {
            gridButtons[i] = inventoryGrid[i].GetComponentInParent<Button>();
        }

        for (int i = 0; i < inventoryGrid.Length; i++)
        {
            if (i < playerInventory.Items.Count)
            {
                SetSkin(playerInventory.Items[i]);
            }
            else
            {
                inventoryGrid[i].sprite = emptySprite;
            }
        }
    }

    public void SetupInventory()
    {
        MoveInventoryUIGrid(gridParentTransform);
        SetupInventoryWithCustomAction(SetSkin);
    }

    public void SetupInventoryWithCustomAction(Action<ItemInstance> action, ItemData.ItemType itemTypeFilter = ItemData.ItemType.None)
    {
        for (int i = 0; i < inventoryGrid.Length; i++)
        {
            Button button = gridButtons[i];
            button.onClick.RemoveAllListeners();
            if (i < playerInventory.Items.Count)
            {
                int id = i;
                inventoryGrid[i].sprite = playerInventory.Items[i].itemData.ItemSprite;
                inventoryGrid[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = playerInventory.Items[i].itemData.ItemCost + "<color=yellow>$</color>";

                button.interactable = !playerInventory.Items[i].equipped;
                if (button.interactable && itemTypeFilter != ItemData.ItemType.None)
                {
                    button.interactable = playerInventory.Items[i].itemData.ItemDataType == itemTypeFilter;
                }

                button.onClick.AddListener(() => action(playerInventory.Items[id]));
            }
            else
            {
                gridButtons[i].interactable = true;
                inventoryGrid[i].sprite = emptySprite;
                inventoryGrid[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = "0<color=yellow>$</color>";
            }
        }
    }

    void UpdateEquipButtons()
    {
        for (int i = 0; i < inventoryGrid.Length; i++)
        {
            if (i < playerInventory.Items.Count)
            {
                gridButtons[i].interactable = !playerInventory.Items[i].equipped;
            }
            else
            {
                gridButtons[i].interactable = true;
            }
        }
    }

    public void MoveInventoryUIGrid(Transform newParent)
    {
        gridTransform.SetParent(newParent, false);
    }

    void SetSkin(ItemInstance itemInstance)
    {
        ItemData itemData = itemInstance.itemData;
        switch (itemData.ItemDataType)
        {
            case ItemData.ItemType.Face:
                SetSkinValues(ref faceItem, itemInstance, face, itemData.ItemSprite);
                break;
            case ItemData.ItemType.Hood:
                SetSkinValues(ref hoodItem, itemInstance, hood, itemData.ItemSprite);
                break;
            case ItemData.ItemType.Pelvis:
                SetSkinValues(ref pelvisItem, itemInstance, pelvis, itemData.ItemSprite);
                break;
            case ItemData.ItemType.Torso:
                SetSkinValues(ref torsoItem, itemInstance, torso, itemData.ItemSprite);
                break;
        }

        UpdateEquipButtons();

        void SetSkinValues(ref ItemInstance currentItem, ItemInstance newItem, Image portrait, Sprite newSprite)
        {
            if (currentItem != null)
                currentItem.equipped = false;

            currentItem = newItem;
            currentItem.equipped = true;
            customizations.SetOutfit(currentItem.itemData.ItemDataType, newSprite);
            portrait.sprite = newSprite;
        }
    }
}
