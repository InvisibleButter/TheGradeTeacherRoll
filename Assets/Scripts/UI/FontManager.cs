using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontManager : MonoBehaviour
{
    public static FontManager Instance { get; set; }
    
    public List<TMP_FontAsset > Fonts = new List<TMP_FontAsset >();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    public TMP_FontAsset  GenerateFont()
    {
        return Fonts[Random.Range(0, Fonts.Count)];
    }
}
