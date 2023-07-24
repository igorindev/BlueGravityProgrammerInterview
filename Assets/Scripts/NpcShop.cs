using UnityEngine;

public class NpcShop : Npc, IInteractable
{
    [SerializeField] ItemsDataCollection itemsSoldByThisNPC;
    [SerializeField] int shopId;

    public void StartInteraction()
    {
        GameManager.Instance.ShowShop(itemsSoldByThisNPC.GetAllItemsData(), shopId);
    }

    public void StopInteraction()
    {

    }
}
