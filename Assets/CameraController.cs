using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator animator;
    public void DeskView()
    {
        animator.SetTrigger("Desk");
    }

    public void ClassView()
    {
        animator.SetTrigger("Class");
    }

    public void ExamView()
    {
        animator.SetTrigger("Exam");
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            DeskView();
        }
        if (Input.GetKey(KeyCode.S))
        {
            ClassView();
        }
        if (Input.GetKey(KeyCode.D))
        {
            ExamView();
        }
    }
}
