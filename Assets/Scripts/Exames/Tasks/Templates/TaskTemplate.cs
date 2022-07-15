using UnityEngine;

namespace Exames.Tasks.Templates
{
    public abstract class TaskTemplate : ScriptableObject, ITaskBuildable
    {
        public abstract string Question { get; }
        public abstract string[] Corrects { get; }
        public abstract string[] Wrongs { get; }
    }
}