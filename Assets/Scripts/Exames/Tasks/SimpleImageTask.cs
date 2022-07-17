using UnityEngine;

namespace Exames.Tasks
{
    public class SimpleImageTask : SimpleTask
    {
        public Sprite Image { get; }

        public SimpleImageTask(TaskType type, string text, string answer, bool correct, Sprite image) : base(type, text, answer, correct)
        {
            Image = image;
        }
    }
}