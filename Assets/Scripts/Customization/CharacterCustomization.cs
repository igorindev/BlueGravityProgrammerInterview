using System;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField] Outfit face;
    [SerializeField] Outfit hood;
    [SerializeField] Outfit pelvis;
    [SerializeField] Outfit torso;

    public void SetOutfit(ItemData.ItemType itemDataType, Sprite newSprite)
    {
        switch (itemDataType)
        {
            case ItemData.ItemType.Face:
                face.Replace(newSprite);
                break;
            case ItemData.ItemType.Hood:
                hood.Replace(newSprite);
                break;
            case ItemData.ItemType.Pelvis:
                pelvis.Replace(newSprite);
                break;
            case ItemData.ItemType.Torso:
                torso.Replace(newSprite);
                break;
        }
    }
}

[Serializable]
public class Outfit
{
    [SerializeField] SpriteRenderer renderer;

    public void Replace(Sprite sprite)
    {
        renderer.sprite = sprite;
    }
}
