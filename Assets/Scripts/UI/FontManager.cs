using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Exames.Subjects;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FontManager : MonoBehaviour
{
    public static FontManager Instance { get; set; }
    
    public List<TMP_FontAsset > Fonts = new List<TMP_FontAsset >();

    public List<Sprite> CorrectSprites = new List<Sprite>();
    public List<Sprite> WrongSprites = new List<Sprite>();

    public List<FolderMaterials> FolderMats = new List<FolderMaterials>();

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

    public Sprite GetCorrectSprite()
    {
        if (!CorrectSprites.Any())
        {
            return null;
        }
        return CorrectSprites[Random.Range(0, CorrectSprites.Count)];
    } 
    public Sprite GetWrongSprite()
    {
        if (!WrongSprites.Any())
        {
            return null;
        }
        return WrongSprites[Random.Range(0, CorrectSprites.Count)];
    }

    public Material GetMaterialForSubject(string subject)
    {
        return FolderMats.FirstOrDefault(each=>each.Name == subject).Material;
    }

    [Serializable]
    public class FolderMaterials
    {
        public string Name;
        public Material Material;
    }
}
