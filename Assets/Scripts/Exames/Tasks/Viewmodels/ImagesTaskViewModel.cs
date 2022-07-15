using Exames.Tasks;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImagesTaskViewModel : TaskViewModel
{
   public Image Icon;
   public TMP_Text Question, Answer;
   
   public override void Setup(Task task)
   {
      base.Setup(task);

      Question.text = task.Question;
      Answer.text = task.Answer;
      
      //todo load icon from ressource
   }
}
