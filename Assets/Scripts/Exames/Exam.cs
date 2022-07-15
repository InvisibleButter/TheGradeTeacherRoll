using System;

namespace Exames
{
    public class Exam<T>
    {
        public T Grade { get; private set; }

        public event Action<T> OnGradeChanged;

        public Exam(T grade)
        {
            Grade = grade;
        }

        private void SetGrade(T grade)
        {
            var old = Grade;
            Grade = grade;
            OnGradeChanged?.Invoke(old);
        }
    }
}
