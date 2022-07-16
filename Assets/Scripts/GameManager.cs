using System;
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
      StartCorrectionPhase();
   }

   private void StartCorrectionPhase()
   {
      _diceManager.RollDices();
      _examManager.GenerateNewExams(5);
   }
}
