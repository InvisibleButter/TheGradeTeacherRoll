using Exames.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TaskViewModel : MonoBehaviour
{
    public Image CorrectionIcon; 
    public Sprite WrongSprite, CorrectSprite;

    private int _correctionIndex;
    protected Task _currentTask;

    public virtual void Setup(Task task)
    {
        _currentTask = task;
        _correctionIndex = 0;
        SetCorrection();
    }

    private void SetCorrection()
    {
        if (_correctionIndex == 0)
        {
            CorrectionIcon.gameObject.SetActive(false);
        }
        else
        {
            CorrectionIcon.gameObject.SetActive(true);
            CorrectionIcon.sprite = _correctionIndex == 1 ? CorrectSprite : WrongSprite;
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
