namespace Exames.Tasks
{
    public interface ITask
    {
        public string Question { get; }
        public string[] Answers { get; }
        public int RightPoints { get; }
        public int MaxPoints { get;  }
        
        public TaskType Type { get; }

        public int TeacherPoints { get; }
        public void AddTeacherPoint();
        public void RemoveTeacherPoint();
        
        public bool Marked { get; set; }
    }
}