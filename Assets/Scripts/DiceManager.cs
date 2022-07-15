using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public GameManager DiceDummyPrefab;
    public int StartDiceAmount = 10;
    
    private List<Dice> _dices = new List<Dice>();

    private int _diceAmount;

    private void Start()
    {
        _diceAmount = StartDiceAmount;
    }

    public void RollDices()
    {
        //do whatever you want
        for (int i = 0; i < _diceAmount; i++)
        {
            
        }
    }

    public void AddDice()
    {
        _diceAmount++;
    }
}
