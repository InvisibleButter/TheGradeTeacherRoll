using System;
using UnityEngine;

namespace Exames
{
    public class ExamManager : MonoBehaviour
    {
        public ExamRenderer renderer;
        public Exam<byte> Exam
        {
            get;
            private set;
        }
        
        private void Awake()
        {
            Exam = new Exam<byte>(5);
            renderer.SetExam(Exam);
        }
    }
}