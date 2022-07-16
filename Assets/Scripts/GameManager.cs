using System;
using DG.Tweening;
using Exames;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; set; }

   [SerializeField]
   private DiceManager _diceManager;

   [SerializeField] 
   private ExamManager _examManager;

   public int MaxSchoolWeeks = 3;
   private int _currentWeeksFinished;
   private int _currenTestPhasesFinished;
   private bool _onRollingDices, _gameStarted;

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
      DOTween.Init();
      _gameStarted = true;
      _diceManager.OnAllDicesRolled += AllDicesRolled;
      StartCorrectionPhase();
   }

   private void StartCorrectionPhase()
   {
      _onRollingDices = true;
      _diceManager.RollDices();
   }

   private void AllDicesRolled()
   {
      _onRollingDices = false;
      Debug.Log("*** all rolled");
      
      _examManager.GenerateNewExams(5);
   }
}
