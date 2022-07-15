using System;

namespace Exames.Tasks
{
    public class SimpleTask
    {
        public string Question { get; }
        public string Answer { get; }
        public bool Correct { get; }
        
        public TaskType Type { get; }

        public SimpleTask(TaskType type, string text, string answer, bool correct)
        {
            Type = type;
            Question = text;
            Answer = answer;
            Correct = correct;
        }
    }
}