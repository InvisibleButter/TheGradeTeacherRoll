using UnityEngine;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "ImageTask", menuName = "Task/ImageTask", order = 0)]
    public class SimpleImageTaskTemplate : TaskTemplate
    {

        [SerializeField] private Sprite image;

        public override int MaxPoints => 1;

        public override ITask Generate(System.Random random)
        {
            var correct = random.Next(0, 100) < geniusSCore;
            
            var choosen = correct ? base.correct : wrong;
            var index = random.Next(0, choosen.Length);

            return new SimpleImageTask(TaskType.IMAGE, question, choosen[index], correct, image);
        }
    }
        
}