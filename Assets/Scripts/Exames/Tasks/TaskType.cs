using System;
using Exames.Tasks;
using Exames.Tasks.Templates;

namespace Exames
{
    public enum TaskType
    {
        SINGLE_LINE,
        IMAGE,
        FULL_TEXT
    }
    
    public static class Extensions
    {
        public static SimpleTask Create(this TaskType type, string text, string answer, bool correct, ITaskBuildable buildable)
        {
            switch (type)
            {
                case TaskType.SINGLE_LINE: return new SimpleTask(type, text, answer, correct);
                case TaskType.IMAGE:
                    return new SimpleImageTask(type, text, answer, correct,
                        (buildable as SimpleImageTaskTemplate).Image);
                default: throw new Exception(type + " is not implemented yet!");
            }
        }
    }
}