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
}
