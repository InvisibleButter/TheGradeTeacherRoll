using Exames;
using Exames.Tasks;
using TMPro;

public class SingeLineTaskViewModel : TaskViewModel
{
    public TMP_Text AnswerTxt, QuestionTxt;

    public override void Setup(Exam exam, ITask task)
    {
        base.Setup(exam, task);

        AnswerTxt.text = task.Answers[0];
        AnswerTxt.font = exam.AnswerFont;
        QuestionTxt.text = task.Question;
    }
}
