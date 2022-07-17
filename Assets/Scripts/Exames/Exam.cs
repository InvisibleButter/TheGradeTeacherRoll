using System;
using System.Linq;
using Exames.Subjects;
using Exames.Tasks;
using TMPro;
using UnityEngine;

namespace Exames
{
    public class Exam
    {
        public Subject Subject { get; }
        public byte Grade { get; private set; }
        public int Points { get; private set; }
        public int MaxPoints { get; }
        public int RealPoints { get; private set; }
        public byte RealGrade { get; private set; }
        public ITask[] Tasks { get; }
        public event Action<byte> OnGradeChanged;
        public event Action OnPointsChanged;
        
        public TMP_FontAsset  AnswerFont { get; private set; }
        
        public Sprite CorrectSprite { get; private set; }
        public Sprite WrongSprite { get; private set; }
        public bool IsFinished { get; set; }

        public bool CanFinish
        {
            get
            {
                if (Tasks.All(each => each.Marked) /*&& CurrentDice != null*/)
                {
                    return true;
                }

                return false;
            }
        }

        public Dice CurrentDice { get; set; }

        public void SetDice(Dice d)
        {
            if (CurrentDice != null)
            {
                CurrentDice.IsLocked = false;
            }
            
            CurrentDice = d;
            CurrentDice.IsLocked = true;
        }
        
        public Exam(Subject subject, ITask[] tasks)
        {
            Subject = subject;
            Tasks = tasks;
            Grade = 0;
            Points = 0;

            MaxPoints = Tasks.Sum(task => task.MaxPoints);

            AnswerFont = FontManager.Instance.GenerateFont();
            CorrectSprite = FontManager.Instance.GetCorrectSprite();
            WrongSprite = FontManager.Instance.GetWrongSprite();
            
            CalculateRealGrade();
        }

        public void MarkTask(ITask task, bool correct)
        {
            task.Marked = true;
            if (correct)
            {
                task.AddTeacherPoint();
            }
            else
            {
                task.RemoveTeacherPoint();
            }

            Points = Tasks.Sum(task => task.TeacherPoints);
            
            OnPointsChanged?.Invoke();
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
                if (simpleTask.RightPoints > 0)
                {
                    RealPoints += Points;
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
