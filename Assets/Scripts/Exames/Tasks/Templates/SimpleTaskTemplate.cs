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

            if (choosen.Length == 0)
            {
                Debug.Log("I have a problem: " + name);
            }

            if (index >= choosen.Length)
            {
                Debug.Log("I have many problems: " + name);
            }
            
            return new SimpleTask(TaskType.SINGLE_LINE, question, choosen[index], correct);
        }
    }
}