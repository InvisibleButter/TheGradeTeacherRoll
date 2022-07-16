namespace Exames.Tasks.Templates
{
    public interface ITaskBuildable
    {
        public string Question { get; }
        public string[] Corrects { get; }
        public string[] Wrongs { get; }
        
        public TaskType Type { get; }
    }
}