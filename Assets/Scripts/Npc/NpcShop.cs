using System.Collections.Generic;
using UnityEngine;

public class NpcShop : Npc, IInteractable
{
    [SerializeField] ItemsDataCollection globalItems;
    [SerializeField] List<ItemInstance> itemsSoldByThisNPC;

    Vector2Int itemsRangeToSell = new Vector2Int(4, 8);

    void Start()
    {
        int quantityToSell = Random.Range(itemsRangeToSell.x, itemsRangeToSell.y);
        itemsSoldByThisNPC = new List<ItemInstance>(quantityToSell);
        for (int i = 0; i < quantityToSell; i++)
        {
            ItemInstance itemInstance = new ItemInstance()
            {
                itemData = globalItems.GetRandomItem(),
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
