using System;

namespace Exames.Tasks
{
    public class SimpleTask : ITask
    {
        public string Question { get; }

        public string[] Answers { get; }
        public int RightPoints { get; }
        
        public int MaxPoints { get; }

        public TaskType Type { get; }
        
        public int TeacherPoints { get; private set; }
        public void AddTeacherPoint()
        {
            TeacherPoints = 1;
        }

        public void RemoveTeacherPoint()
        {
            TeacherPoints = 0;
        }

        public bool Marked { get; set; }

        public SimpleTask(TaskType type, string text, string answer, bool correct)
        {
            Type = type;
            Question = text;
            Answers = new []{answer};
            RightPoints = correct ? 1 : 0;
            MaxPoints = 1;
        }
    }
}