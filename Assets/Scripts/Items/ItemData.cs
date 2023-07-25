using UnityEngine;

[CreateAssetMenu()]
public class ItemData : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Sprite itemSprite;
    [SerializeField] int itemCost;

    public string ItemName { get => itemName; }
    public Sprite ItemSprite { get => itemSprite; }
    public int ItemCost { get => itemCost; }

#if UNITY_EDITOR
    public void SetupAllItemDataValues(string itemName, Sprite itemSprite, int itemCost)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemCost = itemCost;
    }
#endif
}
