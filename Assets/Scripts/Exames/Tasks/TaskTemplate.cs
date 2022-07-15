using UnityEngine;

namespace Exames.Tasks
{
    [CreateAssetMenu(fileName = "Task", menuName = "Exam", order = 0)]
    public class TaskTemplate : ScriptableObject, ITask
    {

        [SerializeField] public string question;
        [SerializeField] public string answer;
        [SerializeField] public bool correction;
        
        public string Question => question;

        public string Answer => answer;

        public bool Correct => correction;
    }
}