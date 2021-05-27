using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dialogueManager;
    public GameObject player;


    private bool wasNotOpened = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player") && wasNotOpened)
        {
            startAnim.SetBool("startOpen", true);
            wasNotOpened = false;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            startAnim.SetBool("startOpen", false);
            dialogueManager.EndDialog();
        }
    }

    
}
