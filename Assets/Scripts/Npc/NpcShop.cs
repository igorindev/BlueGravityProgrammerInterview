using System.Collections.Generic;
using UnityEngine;

public class NpcShop : Npc, IInteractable
{
    [SerializeField] ItemsDataCollection itemsCollection;
    [SerializeField] List<ItemInstance> itemsSoldByThisNPC;

    public ItemData.ItemType NpcShopType => itemsCollection.ItemType;

    void Start()
    {
        int quantityToSell = Random.Range(4, itemsCollection.ItemsCount);
        itemsSoldByThisNPC = new List<ItemInstance>(quantityToSell);

        ItemData[] items = itemsCollection.GetAllItemsData();
        for (int i = 0; i < items.Length; i++)
        {
            ItemInstance itemInstance = new ItemInstance()
            {
                itemData = items[i],
            };

            itemsSoldByThisNPC.Add(itemInstance);
        }
    }

    public void AddItemToNpc(ItemInstance itemData)
    {
        itemsSoldByThisNPC.Add(itemData);
    }
    public void RemoveItemFromNpc(ItemInstance item)
    {
        itemsSoldByThisNPC.Remove(item);
    }

    public void StartInteraction()
    {
        GameManager.Instance.ShowShop(this, itemsSoldByThisNPC);
    }

    public void StopInteraction()
    {

    }
}
