using Currencies;
using Exames.Subjects;
using TMPro;
using UnityEngine;

namespace Report
{
    public class WeeklyReportRenderer : MonoBehaviour
    {

        [SerializeField] private TMP_Text weekDisplay;
        [SerializeField] private TMP_Text correctionRateDisplay;
        [SerializeField] private TMP_Text correctionGradRateDisplay;
        [SerializeField] private TMP_Text saleryDisplay;
        [SerializeField] private TMP_Text briebeDisplay;

        [SerializeField] private GameObject subjectHolder;
        [SerializeField] private TMP_Text subjectDisplay;
        
        [SerializeField] private GameObject strikeHolder;

        public void Display(WeeklyReport report)
        {
            return;
            subjectHolder.gameObject.SetActive(false);
            weekDisplay.text = $"{report.Week}/{report.MaxWeek}";
            correctionRateDisplay.text = $"{report.CorrectionRate} %";
            correctionGradRateDisplay.text = $"{report.CorrectGradeRate} %";
            saleryDisplay.text = CurrencyManager.Display(report.Salery);
            briebeDisplay.text = CurrencyManager.Display(report.Briebe);
        }

        public void DisplayNewSubject(Subject newSubject)
        {
            return;
            subjectHolder.SetActive(true);
            subjectDisplay.text = newSubject.name;
        }

        public void DisplayNewStrike()
        {
            return;
            strikeHolder.SetActive(true);
        }
    }
}