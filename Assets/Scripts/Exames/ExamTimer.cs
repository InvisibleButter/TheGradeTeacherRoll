using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Exames
{
    public class ExamTimer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text timeText;
        
        private float timeRemaining;

        private YieldInstruction wait;

        public event Action OnTimerFinish;

        private void Awake()
        {
            wait = new WaitForEndOfFrame();
        }

        public void SetTime(int amount)
        {
            timeRemaining = amount;
            StartCoroutine(nameof(Timer));
        }

        public void StopTimer()
        {
            StopAllCoroutines();
        }

        private IEnumerator Timer()
        {
            while (true)
            {
             
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime; 
                    DisplayTime(timeRemaining);
                }
                else
                {
                    StopTimer();
                    timeRemaining = 0;
                    OnTimerFinish?.Invoke();
                    break;
                }

                yield return wait;   
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}