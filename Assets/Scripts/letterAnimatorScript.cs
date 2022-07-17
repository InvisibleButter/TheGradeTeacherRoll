using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterAnimatorScript : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    public void OpenLetter()
    {
        anim.SetTrigger("openLetter");
    }
}
