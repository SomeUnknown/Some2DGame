using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow)
         || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            anim.SetTrigger("Jump");
    }
}
