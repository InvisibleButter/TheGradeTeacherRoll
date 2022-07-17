using Currencies;
using DG.Tweening;
using Exames;
using Report;
using Strikes;
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
   
   [SerializeField]
   private CameraController _cameraController;

   public NameGenerator NameGenerator => _nameGenerator;
   public CurrencyManager CurrencyManager => _currencyManager;

   public DiceManager DiceManager => _diceManager;

   public int MaxSchoolWeeks = 3;
   public int MaxExams = 10;
   private int _currentWeeksFinished, _yearFinished;
   private bool _onRollingDices, _gameRunning;
   protected bool _isFirstStart = true;

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
      
      _cameraController.ClassView();
   }

   public void StartGame()
   {
      _cameraController.DeskView();
      _diceManager.OnAllDicesRolled += AllDicesRolled;
      StartCorrectionPhase();
      _gameRunning = true;
   }

   public void StartCorrectionPhase()
   {
      //TODO check for max strike
      if (StrikeManager.INSTANCE.MaxStrikes == StrikeManager.INSTANCE.Strikes)
      {
         StrikeManager.INSTANCE.GiveLastLetter();
      }
      else
      {
         _onRollingDices = true;
         _diceManager.RollDices();  
      }
   }

   private void AllDicesRolled()
   {
      _onRollingDices = false;
      _examManager.GenerateNewExams(MaxExams);
      _cameraController.ExamView();
   }

   public void FinishWeek()
   {
      StartNextWeek();
      _currencyManager.Add(_currencyManager.WeeklySalery);
      _weeklyReportManager.StartWeeklyReport(_currentWeeksFinished, MaxSchoolWeeks, _currencyManager.WeeklySalery, _examManager.CurrentExams, null);
   }
   public void StartNextWeek()
   {
      ++_currentWeeksFinished;
      if (_currentWeeksFinished >= MaxSchoolWeeks)
      {
         StartNextYear();
      }
      else
      {
         Debug.Log("*** start next week: " + _currentWeeksFinished);
      }
   }

   private void StartNextYear()
   {
      _yearFinished++;
      _currentWeeksFinished = 0;
      Debug.Log("*** start next year: " + _yearFinished);
      //todo maybe some ui here to say go ahead?
   }

   public void IngamePlayButton()
   {
      if (_isFirstStart)
      {
         StartGame();
         _isFirstStart = false;
      }
      else
      {
         PauseGame(_gameRunning);
      }
   }
   
   public void PauseGame(bool isPaused)
   {
      _gameRunning = !isPaused;
      if (isPaused)
      {
         _cameraController.ClassView();
      }
      else
      {
         _cameraController.ExamView();
      }
   }
}
