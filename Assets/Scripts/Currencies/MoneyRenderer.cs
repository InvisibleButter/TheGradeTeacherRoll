using System.Collections;
using System.Collections.Generic;
using Currencies;
using UnityEngine;

public class MoneyRenderer : MonoBehaviour
{
    public float ScaleFactor;
    public GameObject Dollar;
    private void Start()
    {
        GameManager.Instance.CurrencyManager.OnMoneyChanged += Render;
        Render(0);
    }
    
    private void Render(int oldAmount)
    {
        int money = GameManager.Instance.CurrencyManager.Money;
        Dollar.SetActive(money != 0);
        if (money > 0)
        {
            Vector3 target = Vector3.one;
            target.y = money * ScaleFactor;
            transform.localScale = target;
        }
    }
}
