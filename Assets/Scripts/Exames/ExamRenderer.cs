using System;
using System.Collections.Generic;
using System.Linq;
using Exames.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Exames
{
    public class ExamRenderer : MonoBehaviour
    {

        [SerializeField] private TMPro.TMP_Text display;

        [CanBeNull] private Exam _exam;
        public List<TaskIdentifier> Tasks = new List<TaskIdentifier>();
        public GameObject TasksHolder;
        private List<GameObject> _tasks;

        public void SetExam(Exam exam)
        {
            if (_exam != null)
            {
                throw new Exception("Exam already set!");
            }

            _exam = exam;
            _exam.OnGradeChanged += RenderGrade;

            Render();
        }

        private void Render()
        {
            RenderGrade(0);
            RenderTasks();
        }
        
        private void RenderGrade(byte oldValue)
        {
            display.text = _exam.Grade == 0 ? "" : _exam.Grade.ToString();
        }

        private void RenderTasks()
        {
            _tasks = new List<GameObject>();
            for (int i = 0; i < _exam.Tasks.Length; i++)
            {
                SimpleTask task = _exam.Tasks[i];
                GameObject go = Instantiate(Tasks.First(each => each.Type == task.Type).Prefab, TasksHolder.transform);
                TaskViewModel vm = go.GetComponent<TaskViewModel>();
                vm.Setup(task);
                _tasks.Add(go);
            }
        }
        
        private void Clear()
        {
            if (_exam != null)
            {
                _exam.OnGradeChanged -= RenderGrade;
            }

            foreach (var task in _tasks)
            {
                Destroy(task);
            }

            _tasks.Clear();
            _exam = null;
        }

        [Serializable]
        public class TaskIdentifier
        {
            public TaskType Type;
            public GameObject Prefab;
        }
    }
}
