using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
    public GameObject DiceDummyPrefab;
    
    public int StartDiceAmount = 10;
    
    private List<Dice> _dices = new List<Dice>();

    private int _diceAmount;
    private int _finishedDice;

    //maybe event later
    public bool rollingFinished = false;

    private void Start()
    {
        _diceAmount = StartDiceAmount;
        for(int i=0;i<_diceAmount;i++)
        {
            Dice dice = Instantiate(DiceDummyPrefab,transform).GetComponentInChildren<Dice>();
            dice.diceRollFinishedEvent = new UnityEvent();
            dice.diceRollFinishedEvent.AddListener(DiceFinished);
            _dices.Add(dice);
        }
        RollDices();
    }

    public void RollDices()
    {
        for (int i = 0; i < _diceAmount; i++)
        {
            _dices[i].RollDice();
        }
        rollingFinished = false;
        _finishedDice = 0;
    }

    public void AddDice()
    {
        _diceAmount++;
        Dice dice = Instantiate(DiceDummyPrefab, transform).GetComponent<Dice>();
        dice.diceRollFinishedEvent.AddListener(DiceFinished);
        _dices.Add(dice);
    }

    public void DiceFinished()
    {
        _finishedDice++;
        rollingFinished = (_finishedDice == _diceAmount);
        Debug.Log("FINISHED");
    }
}
