using System;

namespace Exames.Tasks
{
    public struct Task : ITask
    {
        public string Question { get; }
        public string Answer { get; }
        public bool Correct { get; }

        public Task(string text, string answer, bool correct)
        {
            Question = text;
            Answer = answer;
            Correct = correct;
        }
    }
}