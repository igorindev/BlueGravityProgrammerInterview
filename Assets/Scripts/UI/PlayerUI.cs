using TMPro;
using UnityEngine;

public class PlayerUI : GameUI
{
    [SerializeField] TextMeshProUGUI moneyValue;
    [SerializeField] TextMeshProUGUI dayTimeValue;

    public void UpdateMoney(int playerMoney)
    {
        moneyValue.text = playerMoney.ToString();
    }

    public void UpdateDayTime(float dayTime)
    {
        dayTimeValue.text = dayTime.ToString();
    }
}
