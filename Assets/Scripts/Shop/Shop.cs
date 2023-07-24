using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] ItemsDataCollection itemsDataCollection;
    [SerializeField] ShopBuyButton baseButtonPrefab;
    [SerializeField] Transform container;

    void Start()
    {
        SetupShop();
    }

    void SetupShop()
    {
        ItemData[] array = itemsDataCollection.GetAllItemsData();
        for (int i = 0; i < array.Length; i++)
        {
            int id = i;
            ShopBuyButton shopBuyButton = Instantiate(baseButtonPrefab, container);
            shopBuyButton.Setup(array[i], Buy);
        }
    }

    public void Buy(int id)
    {

    }

    public void Sell()
    {

    }
}
