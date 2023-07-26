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

    ItemInstance faceItem;
    ItemInstance hoodItem;
    ItemInstance pelvisItem;
    ItemInstance torsoItem;

#if UNITY_EDITOR
    /// <summary>
    /// Auto get all grid slots
    /// </summary>
    /// 
    [Header("EDITOR")]
    [SerializeField] Transform editorGridReference;
    void OnValidate()
    {
        if (editorGridReference == null) return;
        inventoryGrid = new Image[editorGridReference.childCount];
        for (int i = 0; i < editorGridReference.childCount; i++)
        {
            inventoryGrid[i] = editorGridReference.GetChild(i).GetChild(0).GetComponent<Image>();
        }
    }
#endif

    public void Initialize()
    {
        for (int i = 0; i < playerInventory.Items.Capacity; i++)
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
        for (int i = 0; i < playerInventory.Items.Capacity; i++)
        {
            Button button = inventoryGrid[i].GetComponentInParent<Button>();
            button.onClick.RemoveAllListeners();
            if (i < playerInventory.Items.Count)
            {
                int id = i;
                inventoryGrid[i].sprite = playerInventory.Items[i].itemData.ItemSprite;
                button.onClick.AddListener(() => SetSkin(playerInventory.Items[id]));
            }
            else
            {
                inventoryGrid[i].sprite = emptySprite;
            }
        }
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

        void SetSkinValues(ref ItemInstance currentItem, ItemInstance newItem, Image portrait, Sprite newSprite)
        {
            if (currentItem != null)
                currentItem.equipped = false;
            
            currentItem = newItem;
            currentItem.equipped = true;
            customizations.SetPelvis(newSprite);
            portrait.sprite = newSprite;
        }
    }
}
