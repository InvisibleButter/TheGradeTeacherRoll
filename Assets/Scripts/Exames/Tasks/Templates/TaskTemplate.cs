using UnityEngine;

namespace Exames.Tasks.Templates
{
    public abstract class TaskTemplate : ScriptableObject, ITaskBuildable
    {
        private ITaskBuildable _taskBuildableImplementation;
        public abstract string Question { get; }
        public abstract string[] Corrects { get; }
        public abstract string[] Wrongs { get; }
        public abstract TaskType Type { get; }
    }
}