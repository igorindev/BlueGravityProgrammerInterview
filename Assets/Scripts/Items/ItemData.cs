using UnityEngine;

[CreateAssetMenu()]
public class ItemData : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Sprite itemSprite;
    [SerializeField] int itemCost;
    [SerializeField] ItemType itemType;

    public enum ItemType
    {
        None,
        Face,
        Hood,
        Pelvis,
        Torso
    }

    public string ItemName { get => itemName; }
    public Sprite ItemSprite { get => itemSprite; }
    public int ItemCost { get => itemCost; }
    public ItemType ItemDataType { get => itemType; }

#if UNITY_EDITOR
    public void SetupAllItemDataValues(string itemName, Sprite itemSprite, int itemCost, ItemType itemType)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemCost = itemCost;
        this.itemType = itemType;
    }
#endif
}
