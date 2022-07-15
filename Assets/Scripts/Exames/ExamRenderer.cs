using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Exames
{
    public class ExamRenderer : MonoBehaviour
    {

        [SerializeField] private TMPro.TMP_Text display;

        [CanBeNull] private Exam _exam;

        public void SetExam(Exam exam)
        {
            if (_exam != null)
            {
                throw new Exception("Exam already set!");
            }

            _exam = exam;
            _exam.OnGradeChanged += RenderGrade;

            Render();
        }

        private void Render()
        {
            RenderGrade(0);

        }
        
        private void RenderGrade(byte oldValue)
        {
            display.text = _exam.Grade == 0 ? "" : _exam.Grade.ToString();
        }

        private void Clear()
        {
            if (_exam != null)
            {
                _exam.OnGradeChanged -= RenderGrade;
            }

            _exam = null;
        }
    }
}
