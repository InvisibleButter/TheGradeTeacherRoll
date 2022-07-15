using System;
using Exames.Subjects;
using Exames.Tasks;

namespace Exames
{
    public class Exam
    {
        public Subject Subject { get; }
        public byte Grade { get; private set; }
        public Task[] Tasks { get; }
        public event Action<byte> OnGradeChanged;
        
        private bool[] markedTasks;
        private int points;

        public Exam(Subject subject, Task[] tasks)
        {
            Subject = subject;
            Tasks = tasks;
            Grade = 0;
            markedTasks = new bool[tasks.Length];
            points = 0;
        }

        public void MarkTask(int index, bool correct)
        {
            var oldDone = markedTasks[index];
            if (oldDone == correct)
            {
                return;
            }

            if (oldDone)
            {
                --points;
            }
            else
            {
                ++points;
            }

            markedTasks[index] = correct;
            RecalculateGrade();
        }

        private void RecalculateGrade()
        {
            SetGrade((byte)((17 - points) / 3));
        }

        private void SetGrade(byte grade)
        {
            var old = Grade;
            Grade = grade;
            OnGradeChanged?.Invoke(old);
        }
    }
}
