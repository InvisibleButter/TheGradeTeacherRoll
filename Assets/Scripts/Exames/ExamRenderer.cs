using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Exames
{
    public class ExamRenderer : MonoBehaviour
    {

        [SerializeField] private TMPro.TMP_Text display;

        [CanBeNull] private Exam<byte> _exam;

        public void SetExam(Exam<byte> exam)
        {
            if (_exam != null)
            {
                throw new Exception("Exam already set!");
            }

            _exam = exam;
            _exam.OnGradeChanged += Render;
            Render(0);
        }

        private void Render(byte oldValue)
        {
            display.text = _exam.Grade.ToString();
        }

        private void Clear()
        {
            if (_exam != null)
            {
                _exam.OnGradeChanged -= Render;
            }

            _exam = null;
        }
    }
}
