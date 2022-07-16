using Exames;
using Exames.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TaskViewModel : MonoBehaviour
{
    public Image CorrectionIcon; 
    public Sprite WrongSprite, CorrectSprite;

    private int _correctionIndex;
    protected ITask CurrentTask;
    private Exam CurrentExam;

    public virtual void Setup(Exam exam, ITask simpleTask)
    {
        CurrentExam = exam;
        CurrentTask = simpleTask;
        _correctionIndex = 0;
        SetCorrection();
    }

    private void SetCorrection()
    {
        if (_correctionIndex == 0)
        {
            CorrectionIcon.gameObject.SetActive(false);
            CurrentExam.MarkTask(CurrentTask, false);
        }
        else
        {
            CorrectionIcon.gameObject.SetActive(true);
            var correct = _correctionIndex == 1;
            CurrentExam.MarkTask(CurrentTask, correct);
            CorrectionIcon.sprite = correct ? CorrectSprite : WrongSprite;
        }
    }
    
    public void ToggleCorrection()
    {
        _correctionIndex++;
        if (_correctionIndex > 2)
        {
            _correctionIndex = 1;
        }
        SetCorrection();
    }
}
