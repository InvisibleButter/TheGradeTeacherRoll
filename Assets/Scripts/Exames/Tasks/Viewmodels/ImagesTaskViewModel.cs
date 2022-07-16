using Exames;
using Exames.Tasks;
using TMPro;
using UnityEngine.UI;

public class ImagesTaskViewModel : TaskViewModel
{
   public Image Icon;
   public TMP_Text Question, Answer;
   
   public override void Setup(Exam exam, int index, SimpleTask task)
   {
      base.Setup(exam, index, task);

      Question.text = task.Question;
      Answer.text = task.Answer;
      
      //todo load icon from ressource
   }
}
