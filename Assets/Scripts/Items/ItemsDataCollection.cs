using UnityEngine;

[CreateAssetMenu()]
public class ItemsDataCollection : ScriptableObject
{
    [SerializeField] ItemData[] itemsData;

    public ItemData[] GetAllItemsData()
    {
        return itemsData;
    }
}
