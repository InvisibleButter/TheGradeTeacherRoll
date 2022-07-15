using System.Linq;
using UnityEngine;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "SingleAnswer", menuName = "Task", order = 0)]
    public class SingleAnswerTaskTemplate : TaskTemplate, ITaskBuildable
    {
        [SerializeField] public string question;
        [SerializeField] public string correct;
        [SerializeField] public string[] wrong;
        [SerializeField] public bool balancePool = true;

        public override string Question => question;

        public override string[] Wrongs => wrong;

        public override string[] Corrects
        {
            get
            {
                return balancePool ? Enumerable.Repeat(correct, wrong.Length).ToArray() : new[] { correct };
            }
        }

    }
}