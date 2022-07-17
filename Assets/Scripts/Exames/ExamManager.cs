using System.Collections.Generic;
using System.Linq;
using Exames.Subjects;
using UnityEngine;
using Random = System.Random;

namespace Exames
{
    public class ExamManager : MonoBehaviour
    {
        public static ExamManager Instance { get; set; }

        [SerializeField] private Subject[] _subjects;
        [SerializeField] private ExamRenderer renderer;
        [SerializeField] private VisualExamManager _visualExamManager;
        [SerializeField] private ExamTimer _timer;

        [SerializeField] private int timerDuration = 120;

        private List<Exam> _currentExams;
        private Exam _currentExam;
        private Random _random;

        private bool isFirstThisWeek = true;
        
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
            
            _random = new Random();
            renderer.gameObject.SetActive(false);
            _timer.OnTimerFinish += FinishAll;
        }

        private void FinishAll()
        {
            _currentExams.FindAll(exam => !exam.IsFinished).ForEach(exam =>
            {
                var dice = GameManager.Instance.DiceManager.Dices.First(dice => !dice.IsLocked);
                exam.SetDice(dice);
                exam.IsFinished = true;
            });
            _currentExam = null;
            FinishExam();
        }

        private Exam CreateNewExam()
        {
            var index = _random.Next(0, _subjects.Length);
            var subject = _subjects[index];
            var tasks = subject.TryGenerateUniqueTasks(11, _random);
            return new Exam(subject, tasks);
        }

        public void GenerateNewExams(int amount)
        {
            _currentExam = null;

            if (_currentExams == null)
            {
                _currentExams = new List<Exam>();
            }
            _currentExams.Clear();
            
            for (int i = 0; i < amount; i++)
            {
                var exam = CreateNewExam();
                _currentExams.Add(exam);
            }
            
            _visualExamManager.Setup(_currentExams);
        }

        public void ShowNextExam()
        {
            if (_currentExam == null)
            {
                _currentExam = _currentExams.FirstOrDefault(each => !each.IsFinished);
            }
            else
            {
                if (!_currentExam.IsFinished)
                {
                    return;
                }
                _currentExam = _currentExams.FirstOrDefault(each => !each.IsFinished);
            }
            
            renderer.gameObject.SetActive(true);
            renderer.SetExam(_currentExam);

            _visualExamManager.HideLastExam();
            if (isFirstThisWeek)
            {
                _timer.SetTime(timerDuration);
                isFirstThisWeek = false;
            }
        }

        public void FinishExam()
        {
            if (_currentExam != null && _currentExam.CanFinish)
            {
                _currentExam.IsFinished = true;
                renderer.Clear();
            }
            
            renderer.gameObject.SetActive(false);
            _currentExam = null;
            
            if (_currentExams.All(each => each.IsFinished))
            {
                _timer.StopTimer();
                isFirstThisWeek = true;
                GameManager.Instance.FinishWeek();
            }
        }

        public void SetDice(Dice d)
        {
            if (_currentExam is { CanFinish: true })
            {
                _currentExam.SetDice(d);
                FinishExam();
            }
        }

        public void ShowDiceVal(Dice d, bool b)
        {
            renderer.ShowDiceGrade(b, d.result);
        }
    }
}
