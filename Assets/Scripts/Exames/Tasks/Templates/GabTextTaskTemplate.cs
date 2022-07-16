using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "GapTextTask", menuName = "Task/GapText", order = 0)]
    public class GabTextTaskTemplate : TaskTemplate
    {
        public override int MaxPoints => correct.Length;
        protected override bool IsBalanceAble => false;
        public override ITask Generate(Random random)
        {
            var rightPoints = random.Next(0, MaxPoints);
            var pattern = Enumerable.Repeat(false, MaxPoints).ToArray();
            for (var i = 0; i < rightPoints; i++)
            {
                pattern[i] = true;
            }
            Shuffle(pattern, random);

            var answers = new string[MaxPoints];
            for (var i = 0; i < answers.Length; i++)
            {
                if (pattern[i])
                {
                    answers[i] = correct[i];
                }
                else
                {
                    answers[i] = wrong[random.Next(0, wrong.Length)];
                }
            }

            return new MultiPointTask(question, answers, rightPoints, MaxPoints, TaskType.GAP_TEXT);
        }
    }
}