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
            var corrects = TryBalance(base.correct, wrong);
            var wrongs = TryBalance(wrong, base.correct);
            var index = random.Next(0, corrects.Length + wrongs.Length);

            var correct = index < corrects.Length;
            var choosen = correct ? corrects : wrongs;
            if (!correct)
            {
                index -= corrects.Length;
            }

            return new SimpleTask(TaskType.SINGLE_LINE, question, choosen[index], correct);
        }
    }
}