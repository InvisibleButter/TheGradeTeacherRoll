using System;
using UnityEngine;

namespace Strikes
{
    public class StrikeManager : MonoBehaviour
    {
        private static StrikeManager _INSTANCE;

        public static StrikeManager INSTANCE => _INSTANCE;

        private int strikes = 0;
        
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