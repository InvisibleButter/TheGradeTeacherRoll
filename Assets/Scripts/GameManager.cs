using Currencies;
using DG.Tweening;
using Exames;
using Report;
using Students;
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
   
   [SerializeField]
   private WeeklyReportManager _weeklyReportManager;

   public NameGenerator NameGenerator => _nameGenerator;
   public CurrencyManager CurrencyManager => _currencyManager;

   public DiceManager DiceManager => _diceManager;

   public int MaxSchoolWeeks = 3;
   public int MaxExams = 10;
   private int _currentWeeksFinished, _yearFinished;
   private bool _onRollingDices, _gameRunning;

   public bool IsGameRunning => _gameRunning;

   public int SubjectsForYearCount => _yearFinished + 2;
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

      _diceManager.OnAllDicesRolled += AllDicesRolled;
      StartCorrectionPhase();
      _gameRunning = true;
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
      ++_currentWeeksFinished;
      _currencyManager.Add(_currencyManager.WeeklySalery);
      _weeklyReportManager.StartWeeklyReport(_currentWeeksFinished, MaxSchoolWeeks, _currencyManager.WeeklySalery, _examManager.CurrentExams, null);
   }
   public void StartNextWeek()
   {
      //TODO check for max strike
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

   public void PauseGame()
   {
      _gameRunning = !_gameRunning;
   }
}
