using TMPro;
using UnityEngine;

public class PlayerUI : GameUI
{
    [SerializeField] TextMeshProUGUI moneyValue;

    public void UpdateMoney(int playerMoney)
    {
        moneyValue.text = playerMoney.ToString() + " <color=yellow>$</color>";
    }
}
