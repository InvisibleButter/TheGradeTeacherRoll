using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; set; }

   [SerializeField]
   private DiceManager _diceManager;

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
      _gameStarted = true;
      _diceManager.OnAllDicesRolled += AllDicesRolled;
   }

   private void StartCorrectionPhase()
   {
      _onRollingDices = true;
      _diceManager.RollDices();
      //generate exams
   }

   private void AllDicesRolled()
   {
      _onRollingDices = false;
      Debug.Log("*** all rolled");
   }
}
