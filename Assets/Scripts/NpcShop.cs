using UnityEngine;

public class NpcShop : Npc, IInteractable
{
    [SerializeField] ItemsDataCollection itemsSoldByThisNPC;

    public void StartInteraction()
    {
        GameManager.Instance.ShowShop(itemsSoldByThisNPC.GetAllItemsData(), GetHashCode());
    }

    public void StopInteraction()
    {

    }
}
