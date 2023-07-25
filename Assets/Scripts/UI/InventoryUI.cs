using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : GameUI
{
    [SerializeField] CharacterCustomization customizations;
    [SerializeField] Sprite emptySprite;
    [SerializeField] Image[] inventory;

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
        customizations.SetFace(itemData.ItemSprite);
    }
}
