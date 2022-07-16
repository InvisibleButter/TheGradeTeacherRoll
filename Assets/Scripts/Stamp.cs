using Exames;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    private void OnMouseDown()
    {
        ExamManager.Instance.FinishExam();
    }
}
