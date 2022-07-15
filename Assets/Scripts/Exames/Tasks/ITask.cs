namespace Exames.Tasks
{
    public interface ITask
    {
        public string Question { get; }
        public string Answer { get; }
        public bool Correct { get; }
    }
}