using UnityEngine.UI;

namespace Exames.Tasks
{
    public class SimpleImageTask : SimpleTask
    {
        public Image Image { get; }

        public SimpleImageTask(TaskType type, string text, string answer, bool correct, Image image) : base(type, text, answer, correct)
        {
            Image = image;
        }
    }
}