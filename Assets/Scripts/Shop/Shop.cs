using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Canvas shopCanvas;
    [SerializeField] ShopBuyButton baseButtonPrefab;
    [SerializeField] Transform container;

    PlayerMoney playerMoney;

    int lastShopId;

    public void Setup(PlayerMoney playerMoney, ItemData[] shopItemsOptions, int shopId)
    {
        shopCanvas.enabled = true;
        if (lastShopId == shopId) return;

        ClearOldShopValues();
        lastShopId = shopId;

        this.playerMoney = playerMoney;

        for (int i = 0; i < shopItemsOptions.Length; i++)
        {
            int id = i;
            ShopBuyButton shopBuyButton = Instantiate(baseButtonPrefab, container);
            shopBuyButton.Setup(shopItemsOptions[i], Buy);
        }
    }

    public void CloseShop()
    {
        shopCanvas.enabled = false;
        GameManager.Instance.CloseShop();
    }

    public void ClearOldShopValues()
    {
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(0).gameObject);
        }
    }

    public void Buy(ItemData itemData)
    {
        playerMoney.SpendMoney(itemData.ItemCost);
    }

    public void Sell(ItemData itemData)
    {
        playerMoney.AddMoney(itemData.ItemCost);
    }
}
