using System;
using Exames;
using UnityEngine;

public class VisualExamEntry : MonoBehaviour
{
    public Exam Exam { get; private set; }
    public MeshRenderer Renderer;

    public void Setup(Exam exam)
    {
        Exam = exam;

        Renderer.material.color = Exam.Subject.Color;
    }

    public void OnMouseDown()
    {
        //show next Exam if possible
        ExamManager.Instance.ShowNextExam();
    }
}
