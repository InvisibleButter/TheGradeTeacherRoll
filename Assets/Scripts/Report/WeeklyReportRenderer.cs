using System;
using Currencies;
using Exames.Subjects;
using Strikes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private TMP_Text strikeDisplay;

        [SerializeField]
        private Button _button;

        private string strikeTextTemplate;
        private void Awake()
        {
            strikeTextTemplate = strikeDisplay.text;
            _button.onClick.AddListener(OnStartNextWeek);
        }

        private void OnStartNextWeek()
        {
            _button.onClick.RemoveAllListeners();
            WeeklyReportManager.Instance.CloseReport();
        }

        public void Display(WeeklyReport report)
        {
            subjectHolder.gameObject.SetActive(false);
            strikeHolder.gameObject.SetActive(false);
         //   weekDisplay.text = $"{report.Week}/{report.MaxWeek}";
            correctionRateDisplay.text = $"{report.CorrectionRate} %";
            correctionGradRateDisplay.text = $"{report.CorrectGradeRate} %";
            saleryDisplay.text = CurrencyManager.Display(report.Salery);
            briebeDisplay.text = CurrencyManager.Display(report.Briebe);
        }

        public void DisplayNewSubject(Subject newSubject)
        {
            subjectHolder.SetActive(true);
            subjectDisplay.text = newSubject.name;
        }

        public void DisplayNewStrike()
        {
            strikeDisplay.text = string.Format(strikeTextTemplate, StrikeManager.INSTANCE.Strikes + 1);
            strikeHolder.SetActive(true);
        }
    }
}