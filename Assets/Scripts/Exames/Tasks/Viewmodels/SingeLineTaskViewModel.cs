using Exames.Tasks;
using TMPro;

public class SingeLineTaskViewModel : TaskViewModel
{
    public TMP_Text AnswerTxt, QuestionTxt;

    public override void Setup(SimpleTask simpleTask)
    {
        base.Setup(simpleTask);

        AnswerTxt.text = simpleTask.Answer;
        QuestionTxt.text = simpleTask.Question;
    }
}
