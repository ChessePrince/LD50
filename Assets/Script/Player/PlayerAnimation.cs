using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Squash()
    {
        anim.Play("PlayerSquash");
    }
    public void Idle()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle"))
        {
            anim.Play("PlayerIdle");
        }   
    }
}