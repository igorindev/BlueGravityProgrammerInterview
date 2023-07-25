using System;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField] Outfit face;
    [SerializeField] Outfit hood;
    [SerializeField] Outfit pelvis;
    [SerializeField] Outfit torso;

    public void SetFace(Sprite sprite)
    {
        face.Replace(sprite);
    }
    public void SetHood(Sprite sprite)
    {
        hood.Replace(sprite);
    }
    public void SetPelvis(Sprite sprite)
    {
        pelvis.Replace(sprite);
    }
    public void SetTorso(Sprite sprite)
    {
        torso.Replace(sprite);
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
