using System;
using Currencies;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text MoneyTxt;
    private bool _hovered;

    private void Start()
    {
        _hovered = false;
        ToggleHover();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("+++ enter");
        if(!_hovered)
        {
            _hovered = true;
            ToggleHover();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(_hovered)
        {
            _hovered = false;
            ToggleHover();
        }
    }

    private void ToggleHover()
    {
        MoneyTxt.gameObject.SetActive(_hovered);
        if (_hovered)
        {
            MoneyTxt.text = CurrencyManager.Display(GameManager.Instance.CurrencyManager.Money);
        }
    }
    
}
