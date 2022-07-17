using System;
using UnityEngine;

namespace Strikes
{
    public class StrikeManager : MonoBehaviour
    {
        private static StrikeManager _INSTANCE;

        public static StrikeManager INSTANCE => _INSTANCE;

        [SerializeField]
        private GameObject[] blueLetters;
        
        private int strikes = 0;

        public int MaxStrikes => blueLetters.Length;
        
        public int Strikes => strikes;

        private void Awake()
        {
            if (_INSTANCE != null)
            {
                Destroy(gameObject);
                throw new Exception("Duplicated WeeklyReportManager");
            }

            _INSTANCE = this;
            foreach (var blueLetter in blueLetters)
            {
                blueLetter.SetActive(false);
            }
        }

        public void AddNewStrike()
        {
            if (strikes >= blueLetters.Length)
            {
                throw new Exception("Game should already finish");
            }
            blueLetters[strikes].SetActive(true);
            ++strikes;
        }
    }
}