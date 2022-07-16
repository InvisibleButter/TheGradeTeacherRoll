using UnityEngine;
using Random = System.Random;

namespace Exames.Tasks.Templates
{
    public abstract class TaskTemplate : ScriptableObject
    {
        [SerializeField] protected string question;
        [SerializeField] protected string[] correct;
        [SerializeField] protected string[] wrong;
        [SerializeField] protected int geniusSCore = 50;

        public abstract int MaxPoints { get; }

        public abstract ITask Generate(Random random);
    }
}