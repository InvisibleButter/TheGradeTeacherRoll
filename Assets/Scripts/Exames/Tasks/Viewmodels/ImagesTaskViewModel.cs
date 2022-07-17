using Exames;
using Exames.Tasks;
using TMPro;
using UnityEngine.UI;

public class ImagesTaskViewModel : TaskViewModel
{
   public Image Icon;
   public TMP_Text Question, Answer;
   
   public override void Setup(Exam exam, ITask task)
   {
      base.Setup(exam, task);

      Question.text = task.Question;
      Answer.text = task.Answers[0];
      Answer.font = exam.AnswerFont;

      Icon.sprite = (task as SimpleImageTask).Image;
   }
}
