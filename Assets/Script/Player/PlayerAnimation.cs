using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    public string squash;
    public string idle;
    public string run;
    public string jump;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Squash()
    {
        anim.Play("squash");
    }
    public void Idle()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName(idle))
        {
            anim.Play(idle);
        }
        else
            return;
    }
    public void Run()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName(run))
        {
            anim.Play(run);
            Debug.Log("run");
        }
    }
    public void Jump()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName(jump))
        {
            anim.Play(jump);
        }
    }
}