using System.Linq;
using UnityEngine;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "MultipleAnswer", menuName = "Task", order = 0)]
    public class MultipleAnswerTaskTemplate : TaskTemplate, ITaskBuildable
    {
        [SerializeField] public string question;
        [SerializeField] public string[] correct;
        [SerializeField] public string[] wrong;
        [SerializeField] public bool balancePool = true;

        public override string Question => question;

        public override string[] Wrongs => TryBalance(wrong, correct);

        public override string[] Corrects => TryBalance(correct, wrong);

        private string[] TryBalance(string[] toFill, string[] other)
        {
            if (!balancePool)
            {
                return toFill;
            }

            if (toFill.Length >= other.Length)
            {
                return toFill;
            }

            string[] balanced = new string[other.Length];
            int index = 0;
            for (int i = 0; i < balanced.Length; i++)
            {
                balanced[i] = toFill[index];
                if (index++ >= toFill.Length)
                {
                    index = 0;
                }
            }

            return balanced;
        }
    }
}