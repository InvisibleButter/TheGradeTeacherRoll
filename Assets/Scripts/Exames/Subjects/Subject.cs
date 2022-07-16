using System.Collections.Generic;
using System.Linq;
using Exames.Tasks;
using Exames.Tasks.Templates;
using UnityEngine;
using ITask = Exames.Tasks.ITask;

namespace Exames.Subjects
{
    [CreateAssetMenu(fileName = "Subject", menuName = "Exam", order = 0)]
    public class Subject : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private Color color;

        [SerializeField] private TaskTemplate[] _tasks;

        public Color Color => color;
        
        public ITask[] TryGenerateUniqueTasks(int points, System.Random random)
        {
            var tasks = new List<ITask>();
            var uniqueTasks = Enumerable.Range(0, _tasks.Length).ToList();

            while (points > 0)
            {
                if (uniqueTasks.Count == 0)
                {
                    uniqueTasks = Enumerable.Range(0, _tasks.Length).ToList();
                }

                var index = random.Next(0, uniqueTasks.Count);
                var template = _tasks[uniqueTasks[index]];
                uniqueTasks.RemoveAt(index);

                if (template.MaxPoints > points)
                {
                    continue;
                }

                points -= template.MaxPoints;
                
                tasks.Add(template.Generate(random));   
            }

            return tasks.ToArray();
        }
    }
}