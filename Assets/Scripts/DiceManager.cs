using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
    public GameObject DiceDummyPrefab;
    
    public int StartDiceAmount = 10;
    
    private List<Dice> _dices = new List<Dice>();

    public List<Transform> DicePositions = new List<Transform>();
    private Dictionary<int, bool> _freePositions = new Dictionary<int, bool>();

    private int _diceAmount;
    private int _finishedDice;

    //maybe event later
    public bool rollingFinished = false;
    public Transform spawnPosition;
    public event Action OnAllDicesRolled;

    private void Awake()
    {
        _diceAmount = StartDiceAmount;
    }

    private void Start()
    {
        // for(int i=0;i<_diceAmount;i++)
        // {
        //     Dice dice = Instantiate(DiceDummyPrefab,spawnPosition.position,spawnPosition.rotation,spawnPosition).GetComponentInChildren<Dice>();
        //     dice.diceRollFinishedEvent = new UnityEvent();
        //     dice.diceRollFinishedEvent.AddListener(DiceFinished);
        //     _dices.Add(dice);
        // }
        // RollDices();
    }

    public void RollDices()
    {
        if (_dices.Count != _diceAmount)
        {
            int diff = _diceAmount - _dices.Count;
            for(int i=0;i<diff;i++)
            {
                Dice dice = Instantiate(DiceDummyPrefab,spawnPosition.position,spawnPosition.rotation,spawnPosition).GetComponentInChildren<Dice>();
                dice.diceRollFinishedEvent = new UnityEvent<Dice>();
                dice.diceRollFinishedEvent.AddListener(DiceFinished);
                _dices.Add(dice);
            }
        }

        _freePositions.Clear();
        for (int i = 0; i < DicePositions.Count; i++)
        {
            _freePositions.Add(i, true);
        }
        
        
        for (int i = 0; i < _diceAmount; i++)
        {
            // _dices[i].transform.parent.transform.position = spawnPosition.position;
            // _dices[i].transform.parent.transform.rotation = spawnPosition.rotation;
            
            _dices[i].RollDice();
        }
        rollingFinished = false;
        _finishedDice = 0;
    }

    public void AddDice()
    {
        _diceAmount++;
        Dice dice = Instantiate(DiceDummyPrefab, spawnPosition.position, spawnPosition.rotation, spawnPosition).GetComponent<Dice>();
        dice.diceRollFinishedEvent.AddListener(DiceFinished);
        _dices.Add(dice);
    }

    public void DiceFinished(Dice d)
    {
        _finishedDice++;
        rollingFinished = (_finishedDice == _diceAmount);

        Vector3 targetPos = GetEmptyPlace();
       
        d.SetToSLot(targetPos);
        //todo make it work
        //d.transform.parent.DOMove(targetPos, 2f);
        Debug.Log("FINISHED");

        if (rollingFinished)
        {
            OnAllDicesRolled.Invoke();
        }
    }

    private Vector3 GetEmptyPlace()
    {
        int index = _freePositions.First(each => each.Value).Key;
        _freePositions[index] = false;
        return DicePositions[index].position;
    }
}
