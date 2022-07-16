using Exames;
using Exames.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TaskViewModel : MonoBehaviour
{
    public Image CorrectionIcon; 
    public Sprite WrongSprite, CorrectSprite;

    private int _correctionIndex;
    protected SimpleTask CurrentSimpleTask;
    private Exam CurrentExam;
    private int taskId;

    public virtual void Setup(Exam exam, int index, SimpleTask simpleTask)
    {
        CurrentExam = exam;
        CurrentSimpleTask = simpleTask;
        taskId = index;
        _correctionIndex = 0;
        SetCorrection();
    }

    private void SetCorrection()
    {
        if (_correctionIndex == 0)
        {
            CorrectionIcon.gameObject.SetActive(false);
            CurrentExam.MarkTask(taskId, false);
        }
        else
        {
            CorrectionIcon.gameObject.SetActive(true);
            var correct = _correctionIndex == 1;
            CurrentExam.MarkTask(taskId, correct);
            CorrectionIcon.sprite = correct ? CorrectSprite : WrongSprite;
        }
    }
    
    public void ToggleCorrection()
    {
        _correctionIndex++;
        if (_correctionIndex > 2)
        {
            _correctionIndex = 0;
        }
        SetCorrection();
    }
}
