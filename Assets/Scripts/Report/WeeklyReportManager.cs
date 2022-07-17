using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Exames;
using Exames.Subjects;
using Strikes;
using UnityEngine;

namespace Report
{
    public class WeeklyReportManager : MonoBehaviour
    {

        private static WeeklyReportManager INSTANCE;

        [SerializeField] private GameObject WeeklyReportPrefab;

        private GameObject curreentReport;
        private WeeklyReport currentWeeklyReport;

        private void Awake()
        {
            if (INSTANCE != null)
            {
                Destroy(gameObject);
                throw new Exception("Duplicated WeeklyReportManager");
            }

            INSTANCE = this;
        }

        public void CloseReport()
        {
            Destroy(curreentReport);
            if (currentWeeklyReport.IsStrike)
            {
                StrikeManager.INSTANCE.AddNewStrike();
            }
            GameManager.Instance.StartNextWeek();
        }

        public void StartWeeklyReport(int currentWeeksFinished, int maxSchoolWeeks, int currencyManagerWeeklySalery,
            List<Exam> exams, Subject newSubject)
        {
            var gradeCorrectionRate = CalculateGradeCorrectionRate(exams);
            var correctionRate = CalculateCorrectionRate(exams);

            currentWeeklyReport = new WeeklyReport(currentWeeksFinished, maxSchoolWeeks, correctionRate, gradeCorrectionRate,
                currencyManagerWeeklySalery, 0);
            
            curreentReport = Instantiate(WeeklyReportPrefab);
            WeeklyReportRenderer _renderer = curreentReport.GetComponent<WeeklyReportRenderer>();
            
            _renderer.Display(currentWeeklyReport);

            if (newSubject != null)
            {
                _renderer.DisplayNewSubject(newSubject);
            }

            if (currentWeeklyReport.IsStrike)
            {
                _renderer.DisplayNewStrike();
            }
        }

        private int CalculateCorrectionRate(IReadOnlyCollection<Exam> exams)
        {
            var maxPoints = exams.Sum(exam => exam.MaxPoints);
            var correctCorrectedPoints = exams.Sum(exam => Math.Abs(exam.RealPoints - exam.Points));

            var correctionRate = correctCorrectedPoints / maxPoints * 100;
            return correctionRate;
        }

        private static int CalculateGradeCorrectionRate(IReadOnlyCollection<Exam> exams)
        {
            var maxGradeOffsetSum = 5 * exams.Count;
            var gradeOffsetSum = exams.Sum(exam => Math.Abs(exam.Grade - exam.RealGrade));
            
            var gradeCorrectionRate = (maxGradeOffsetSum - gradeOffsetSum) / maxGradeOffsetSum * 100;
            return gradeCorrectionRate;
        }
    }
}