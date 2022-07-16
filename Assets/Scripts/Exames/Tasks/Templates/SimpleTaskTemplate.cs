using UnityEngine;
using Random = System.Random;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "TextTask", menuName = "Task/TextTask", order = 0)]
    public class SimpleTaskTemplate : TaskTemplate
    {
        public override int MaxPoints => 1;

        public override ITask Generate(Random random)
        {
            var correct = random.Next(0, 100) <= geniusSCore;
            
            var choosen = correct ? base.correct : wrong;
            var index = random.Next(0, choosen.Length);

            return new SimpleTask(TaskType.SINGLE_LINE, question, choosen[index], correct);
        }
    }
}