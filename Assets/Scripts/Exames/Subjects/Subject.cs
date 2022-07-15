using System.Collections.Generic;
using System.Linq;
using Exames.Tasks;
using Exames.Tasks.Templates;
using UnityEngine;

namespace Exames.Subjects
{
    [CreateAssetMenu(fileName = "Subject", menuName = "Exam", order = 0)]
    public class Subject : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private Color color;

        [SerializeField] private TaskTemplate[] _tasks;

        public Task[] TryGenerateUniqueTasks(int amount, System.Random random)
        {
            var tasks = new Task[amount];
            var uniqueTasks = Enumerable.Range(0, _tasks.Length).ToList();
            
            for (var i = 0; i < tasks.Length; i++)
            {
                if (uniqueTasks.Count == 0)
                {
                    uniqueTasks = Enumerable.Range(0, _tasks.Length).ToList();
                }

                var index = random.Next(0, uniqueTasks.Count);
                var template = _tasks[uniqueTasks[index]];
                uniqueTasks.RemoveAt(index);
                
                tasks[i] = TaskFactory.Generate(template, random);
            }

            return tasks;
        }
    }
}