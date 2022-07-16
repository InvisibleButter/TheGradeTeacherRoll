using System;

namespace Exames.Tasks
{
    public class MultiPointTask : ITask
    {
        public string Question { get; }
        public string[] Answers { get; }
        public int RightPoints { get; }
        public int MaxPoints { get; }
        public TaskType Type { get; }
        public int TeacherPoints { get; private set; }

        public MultiPointTask(string question, string[] answers, int rightPoints, int maxPoints, TaskType type)
        {
            Question = question;
            Answers = answers;
            RightPoints = rightPoints;
            MaxPoints = maxPoints;
            Type = type;
        }
        
        public void AddTeacherPoint()
        {
            ++TeacherPoints;
        }

        public void RemoveTeacherPoint()
        {
            if (TeacherPoints > 0)
            {
                ++TeacherPoints;
            }
        }
    }
}