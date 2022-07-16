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
            renderer.SetExam(CreateNewExam());
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
            List<Exam> es = new List<Exam>();
            for (int i = 0; i < amount; i++)
            {
                var exam = CreateNewExam();
                es.Add(exam);
            }
            
            _visualExamManager.Setup(es);
        }
    }
}