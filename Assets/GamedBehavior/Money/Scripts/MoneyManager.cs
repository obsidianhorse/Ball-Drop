using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private MoneyContainer _setMoneyData;

    static private MoneyContainer _moneyData;
    static private Text _text;

    private void Start()
    {
        SetFields();
        UpdateInfo();
    }

    private void SetFields()
    {
        _moneyData = _setMoneyData;
    }
    static public void UpdateInfo()
    {
        if (_text != null)
        {
            _text.text = Convert.ToString(_moneyData.money);
        }
    }
    public static int Money
    {
        get 
        {
            return _moneyData.Money;
        }
        set 
        { 
            _moneyData.Money = value; 
        }
    }
    public static Text MoneyText
    {
        set { _text = value; }
    }
}
