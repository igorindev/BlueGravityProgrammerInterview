using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : GameUI
{
    [SerializeField] CharacterCustomization customizations;
    [SerializeField] Sprite emptySprite;
    [SerializeField] Image[] inventory;

    [Header("Portrait")]
    [SerializeField] Image face;
    [SerializeField] Image hood;
    [SerializeField] Image pelvis;
    [SerializeField] Image torso;

    public void SetupInventory()
    {
        for (int i = 0; i < playerInventory.CurrentItems.Capacity; i++)
        {
            inventory[i].GetComponent<Button>().onClick.RemoveAllListeners();
            if (i < playerInventory.CurrentItems.Count)
            {
                int id = i;
                inventory[i].sprite = playerInventory.CurrentItems[i].ItemSprite;
                inventory[i].GetComponent<Button>().onClick.AddListener(() => SetValue(playerInventory.CurrentItems[id]));
            }
            else
            {
                inventory[i].sprite = emptySprite;
            }
        }
    }

    void SetValue(ItemData itemData)
    {
        switch (itemData.ItemDataType)
        {
            case ItemData.ItemType.Face:
                customizations.SetFace(itemData.ItemSprite);
                face.sprite = itemData.ItemSprite;
                break;
            case ItemData.ItemType.Hood:
                customizations.SetHood(itemData.ItemSprite);
                hood.sprite = itemData.ItemSprite;
                break;
            case ItemData.ItemType.Pelvis:
                customizations.SetPelvis(itemData.ItemSprite);
                pelvis.sprite = itemData.ItemSprite;
                break;
            case ItemData.ItemType.Torso:
                customizations.SetTorso(itemData.ItemSprite);
                torso.sprite = itemData.ItemSprite;
                break;
        }
    }
}
