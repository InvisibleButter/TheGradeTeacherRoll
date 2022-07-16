using Exames;
using UnityEngine;

public class VisualExamEntry : MonoBehaviour
{
    public Exam Exam { get; private set; }
    public MeshRenderer Renderer;

    private VisualExamManager _examManager;
    
    public void Setup(Exam exam, VisualExamManager manager)
    {
        _examManager = manager;
        Exam = exam;

        Renderer.material.color = Exam.Subject.Color;
    }
}
