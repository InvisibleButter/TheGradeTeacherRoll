using Exames.Tasks;
using TMPro;

public class SingeLineTaskViewModel : TaskViewModel
{
    public TMP_Text AnswerTxt, QuestionTxt;

    public override void Setup(Task task)
    {
        base.Setup(task);

        AnswerTxt.text = task.Answer;
        QuestionTxt.text = task.Question;
    }
}
