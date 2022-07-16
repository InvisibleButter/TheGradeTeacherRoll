using System;
using Exames.Subjects;
using Exames.Tasks;

namespace Exames
{
    public class Exam
    {
        public Subject Subject { get; }
        public byte Grade { get; private set; }
        public int Points { get; private set; }
        public int MaxPoints => Tasks.Length;
        public int RealPoints { get; private set; }
        public byte RealGrade { get; private set; }
        public SimpleTask[] Tasks { get; }
        public event Action<byte> OnGradeChanged;
        public event Action OnPointsChanged;
        
        private bool[] markedTasks;

        public Exam(Subject subject, SimpleTask[] tasks)
        {
            Subject = subject;
            Tasks = tasks;
            Grade = 0;
            markedTasks = new bool[tasks.Length];
            Points = 0;
            CalculateRealGrade();
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
                --Points;
            }
            else
            {
                ++Points;
            }
            
            OnPointsChanged?.Invoke();
            markedTasks[index] = correct;
            SetGrade(CalculateGrade(Points));
        }
        private void SetGrade(byte grade)
        {
            var old = Grade;
            Grade = grade;
            OnGradeChanged?.Invoke(old);
        }

        private void CalculateRealGrade()
        {
            foreach (var simpleTask in Tasks)
            {
                if (simpleTask.Correct)
                {
                    ++RealPoints;
                }
            }

            RealGrade = CalculateGrade(RealPoints);
        }
        
        private byte CalculateGrade(int points)
        {
            if (points == MaxPoints)
            {
                return 1;
            }
            var switzerGrade = (double)points * 5 / (MaxPoints + 1);
            var rounded = (int)Math.Floor(switzerGrade);
            var germanGrade = rounded - 6;
            return (byte)Math.Abs(germanGrade);
        }

    }
}
