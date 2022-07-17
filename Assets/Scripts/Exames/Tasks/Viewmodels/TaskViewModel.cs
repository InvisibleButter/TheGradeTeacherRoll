using Exames;
using Exames.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskViewModel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image CorrectionIcon; 
    public Sprite WrongSprite, CorrectSprite;

    private int _correctionIndex;
    protected ITask CurrentTask;
    private Exam CurrentExam;

    public Color DefaultCol, HighlightedCol;
    private bool _isHovered;
    public Image BaseImg;

    private Sprite _correctSprite, _wrongSprite;
    
    public virtual void Setup(Exam exam, ITask simpleTask)
    {
        CurrentExam = exam;
        CurrentTask = simpleTask;
        _correctionIndex = 0;
        BaseImg.color = DefaultCol;

        _correctSprite = CurrentExam.CorrectSprite != null ? CurrentExam.CorrectSprite : CorrectSprite;
        _wrongSprite = CurrentExam.WrongSprite != null ? CurrentExam.WrongSprite : WrongSprite;
        
        SetCorrection(false);
    }

    private void SetCorrection(bool update = true)
    {
        if (_correctionIndex == 0)
        {
            CorrectionIcon.gameObject.SetActive(false);
            if(update)
            {
                CurrentExam.MarkTask(CurrentTask, false);
            }
        }
        else
        {
            CorrectionIcon.gameObject.SetActive(true);
            var correct = _correctionIndex == 1;
            CurrentExam.MarkTask(CurrentTask, correct);
            CorrectionIcon.sprite = correct ? _correctSprite : _wrongSprite;
        }
    }

    public void SetCorrectionVal(bool correct)
    {
        var cor = correct ? 1 : 2;
        if(cor != _correctionIndex)
        {
            _correctionIndex = cor;
            SetCorrection();
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isHovered)
        {
            _isHovered = true;
            BaseImg.color = HighlightedCol;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isHovered)
        {
            _isHovered = false;
            BaseImg.color = DefaultCol;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isHovered)
        {
            SetCorrectionVal(eventData.button == PointerEventData.InputButton.Left);
        }
    }
}
