using UnityEngine;
using UnityEngine.UI;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "ImageTask", menuName = "Task/ImageTask", order = 0)]
    public class SimpleImageTaskTemplate : TaskTemplate
    {

        [SerializeField] private Image image;

        public override int MaxPoints => 1;

        public override ITask Generate(System.Random random)
        {
            var corrects = TryBalance(base.correct, wrong);
            var wrongs = TryBalance(wrong, base.correct);
            var index = random.Next(0, corrects.Length + wrongs.Length);

            var correct = index < corrects.Length;
            var choosen = correct ? corrects : wrongs;
            if (!correct)
            {
                index -= corrects.Length;
            }

            return new SimpleImageTask(TaskType.IMAGE, question, choosen[index], correct, image);
        }
    }
        
}