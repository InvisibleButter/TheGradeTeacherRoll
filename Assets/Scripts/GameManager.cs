using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; set; }

   [SerializeField]
   private DiceManager _diceManager;

   public int MaxSchoolWeeks = 3;
   private int _currentWeeksFinished;
   private int _currenTestPhasesFinished;
   
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

   private void Start()
   {
      
   }

   private void StartCorrectionPhase()
   {
      _diceManager.RollDices();
   }
}
