using System;
using DG.Tweening;
using Exames;
using Students;
using Students.Currencies;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; set; }

   [SerializeField]
   private DiceManager _diceManager;

   [SerializeField] 
   private ExamManager _examManager;

   [SerializeField]
   private NameGenerator _nameGenerator;
   
   [SerializeField]
   private CurrencyManager _currencyManager;

   public NameGenerator NameGenerator => _nameGenerator;

   public int MaxSchoolWeeks = 3;
   public int MaxExams = 10;
   private int _currentWeeksFinished, _yearFinished;
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
      _examManager.GenerateNewExams(MaxExams);
   }

   public void FinishWeek()
   {
      _currencyManager.Add(_currencyManager.WeeklySalery);
      //TODO progress ui
      StartNextWeek();
   }
   public void StartNextWeek()
   {
      _currentWeeksFinished++;
      if (_currentWeeksFinished >= MaxSchoolWeeks)
      {
         StartNextYear();
      }
      else
      {
         Debug.Log("*** start next week: " + _currentWeeksFinished);
         StartCorrectionPhase();
      }
   }

   private void StartNextYear()
   {
      _yearFinished++;
      Debug.Log("*** start next year: " + _yearFinished);
      //todo maybe some ui here to say go ahead?

      StartCorrectionPhase();
   }
}
