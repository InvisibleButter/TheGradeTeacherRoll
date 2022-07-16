using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "GapTextTask", menuName = "Task/GapText", order = 0)]
    public class GabTextTaskTemplate : TaskTemplate
    {
        public override int MaxPoints => correct.Length;
        public override ITask Generate(Random random)
        {
            var answers = new string[MaxPoints];
            var correctCount = 0;
            for (var i = 0; i < answers.Length; i++)
            {
                var isCorrect = random.Next(0, 100) < geniusSCore;
                if (isCorrect)
                {
                    ++correctCount;
                    answers[i] = correct[i];
                }
                else
                {
                    answers[i] = wrong[random.Next(0, wrong.Length)];
                }
            }

            return new MultiPointTask(question, answers, correctCount, MaxPoints, TaskType.GAP_TEXT);
        }
    }
}