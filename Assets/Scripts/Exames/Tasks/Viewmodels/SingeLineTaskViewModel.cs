using Exames;
using Exames.Tasks;
using TMPro;

public class SingeLineTaskViewModel : TaskViewModel
{
    public TMP_Text AnswerTxt, QuestionTxt;

    public override void Setup(Exam exam, int index, SimpleTask simpleTask)
    {
        base.Setup(exam, index, simpleTask);

        AnswerTxt.text = simpleTask.Answer;
        QuestionTxt.text = simpleTask.Question;
    }
}
