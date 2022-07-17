using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CorrectionView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color DefaultCol, HighlightedCol;
    public Image BaseImg;
    public TaskViewModel TaskVM;
    
    private bool IsHovered;

    private void Start()
    {
        BaseImg.color = DefaultCol;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!IsHovered)
        {
            IsHovered = true;
            BaseImg.color = HighlightedCol;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsHovered)
        {
            IsHovered = false;
            BaseImg.color = DefaultCol;
        }
    }

    private void Update()
    {
        if (!IsHovered)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            TaskVM.SetCorrectionVal(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            TaskVM.SetCorrectionVal(false);
        }
    }
}
