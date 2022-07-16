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

        private List<Exam> _currentExams;
        private Exam _currentExam;
        private Random _random;
        
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
           //renderer.SetExam(CreateNewExam());
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
            
            renderer.SetExam(_currentExam);

            _visualExamManager.HideLastExam();
        }

        public void FinishExam()
        {
            if (_currentExam != null && _currentExam.CanFinish)
            {
                _currentExam.IsFinished = true;
                renderer.Clear();
            }

            if (_currentExams.All(each => each.IsFinished))
            {
                GameManager.Instance.StartNextWeek();
            }
        }

        public void SetDice(Dice d)
        {
            if (_currentExam != null && _currentExam.CanFinish)
            {
                _currentExam.SetDice(d);   
            }
        }

        public void ShowDiceVal(Dice d, bool b)
        {
            renderer.ShowDiceGrade(b, d.result);
        }
    }
}
