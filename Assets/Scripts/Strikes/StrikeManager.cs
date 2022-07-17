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

        public int Strikes => strikes;

        private void Awake()
        {
            if (_INSTANCE != null)
            {
                Destroy(gameObject);
                throw new Exception("Duplicated WeeklyReportManager");
            }

            _INSTANCE = this;
        }

        public void AddNewStrike()
        {
            ++strikes;
            //TODO display blue letter as indicator
        }
    }
}