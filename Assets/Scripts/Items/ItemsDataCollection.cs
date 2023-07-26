#if UNITY_EDITOR
using System.Collections.Generic;
#endif

using UnityEditor;
using UnityEngine;

[CreateAssetMenu()]
public class ItemsDataCollection : ScriptableObject
{
    [SerializeField] ItemData[] itemsData;

    public ItemData[] GetAllItemsData()
    {
        return itemsData;
    }

    public ItemData GetRandomItem()
    {
        return itemsData[Random.Range(0, itemsData.Length)];
    }

#if UNITY_EDITOR
    [Header("Collection Path")]
    [SerializeField] string spritePath;
    [SerializeField] string savePath;
    [SerializeField] ItemData.ItemType itemType;

    [ContextMenu("Get All Items At Path")]
    void GetAllItems()
    {
        for (int i = 0; i < itemsData.Length; i++)
        {
            DestroyImmediate(itemsData[i], true);
        } 

        string[] assets = AssetDatabase.FindAssets("t:Texture", new[] { spritePath });
        Sprite[] sprite = new Sprite[assets.Length];
        for (int i = 0; i < assets.Length; i++)
        {
            if (AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GUIDToAssetPath(assets[i]))[0].GetType() == typeof(Sprite))
            {
                sprite[i] = (Sprite)AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GUIDToAssetPath(assets[i]))[0];

            }
            else
            {
                sprite[i] = (Sprite)AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GUIDToAssetPath(assets[i]))[1];
            }
        }
        List<ItemData> list = new List<ItemData>();
        for (int i = 0; i < sprite.Length; i++)
        {
            ItemData itemData = CreateInstance(typeof(ItemData)) as ItemData;
            itemData.SetupAllItemDataValues(sprite[i].name, sprite[i], 50, itemType);

            AssetDatabase.CreateAsset(itemData, $"{savePath}/{sprite[i].name}.asset");
            AssetDatabase.SaveAssets();

            list.Add(AssetDatabase.LoadAssetAtPath($"{savePath}/{sprite[i].name}.asset", typeof(ItemData)) as ItemData);
        }

        itemsData = list.ToArray();
    }
#endif
}
