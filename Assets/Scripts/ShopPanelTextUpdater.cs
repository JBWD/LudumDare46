using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopPanelTextUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currencyTextBox;



    public void FixedUpdate()
    {
        UpdateCurrency();
    }
    public void UpdateCurrency()
    {
        currencyTextBox.text = GameManager.Instance.currency.ToString();
    }
}
