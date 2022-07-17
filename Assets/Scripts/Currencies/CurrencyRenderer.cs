using System;
using UnityEngine;

namespace Currencies
{
    public class CurrencyRenderer : MonoBehaviour
    {

        [SerializeField] private TMPro.TMP_Text display;

        private void Start()
        {
            GameManager.Instance.CurrencyManager.OnMoneyChanged += Render;
            Render(0);
        }

        private void Render(int oldAmount)
        {
            display.text = CurrencyManager.Display(GameManager.Instance.CurrencyManager.Money);
        }
    }
}