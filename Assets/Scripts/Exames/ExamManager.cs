using System.Collections.Generic;
using Exames.Subjects;
using UnityEngine;
using Random = System.Random;

namespace Exames
{
    public class ExamManager : MonoBehaviour
    {

        [SerializeField] private Subject[] _subjects;
        [SerializeField] private ExamRenderer renderer;
        [SerializeField] private VisualExamManager _visualExamManager;

        private Random _random;
        
        private void Awake()
        {
            _random = new Random(119);
            CreateNewExam();
        }

        public void CreateNewExam()
        {
            var index = _random.Next(0, _subjects.Length);
            var subject = _subjects[index];
            var tasks = subject.TryGenerateUniqueTasks(3, _random);
            var exam = new Exam(subject, tasks);
            renderer.SetExam(exam);
        }

        public void GenerateNewExams()
        {
            List<Exam> es = new List<Exam>();
            for (int i = 0; i < 10; i++)
            {
                var index = _random.Next(0, _subjects.Length);
                var subject = _subjects[index];
                var tasks = subject.TryGenerateUniqueTasks(3, _random);
                var exam = new Exam(subject, tasks);
                es.Add(exam);
                //renderer.SetExam(exam);
            }
            
            _visualExamManager.Setup(es);
        }
    }
}